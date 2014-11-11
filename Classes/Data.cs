using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        List,       //Get a list of users in the chat room from the server
        Null,        //No command
        Error,
        User,
        FindGame,
        GameFound,
        Ready,
        StartGame,
        Turn,
        Shot,
        ShotResult
    }

    public struct ClientInfo
    {
        public Socket socket;   //Socket of the client
        public string name;  //Name by which the user logged into the chat room
        public bool ready;
        public Board board;
    }

    //The data structure by which the server and the client interact with 
    //each other
    public class Data
    {
        //Default constructor
        public Data()
        {
            this.Command = Command.Null;
            this.Message = null;
            this.Name = null;
        }

        //Converts the bytes into an object of type Data
        public Data(byte[] data)
        {
            //The first four bytes are for the Command
            this.Command = (Command)BitConverter.ToInt32(data, 0);

            int nameLen;
            int passwordLen;
            switch (Command)
            {
                case Command.Login:
                    //The next four store the length of the name
                    nameLen = BitConverter.ToInt32(data, 4);
                    passwordLen = BitConverter.ToInt32(data, 8);

                    Name = nameLen > 0 ? Encoding.UTF8.GetString(data, 12, nameLen) : null;
                    Password = passwordLen > 0 ? Encoding.UTF8.GetString(data, 12 + nameLen, passwordLen) : null;

                    break;
                case Command.Message:
                    //The next four store the length of the name
                    nameLen = BitConverter.ToInt32(data, 4);

                    //The next four store the length of the message
                    int msgLen = BitConverter.ToInt32(data, 8);

                    //This check makes sure that name has been passed in the array of bytes
                    if (nameLen > 0)
                        this.Name = Encoding.UTF8.GetString(data, 12, nameLen);
                    else
                        this.Name = null;

                    //This checks for a null message field
                    if (msgLen > 0)
                        this.Message = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
                    else
                        this.Message = null;
                    break;
                case Command.Logout:
                    //The next four store the length of the name
                    nameLen = BitConverter.ToInt32(data, 4);

                    Name = nameLen > 0 ? Encoding.UTF8.GetString(data, 8, nameLen) : null;

                    break;
                case Command.Error:
                    //The next four store the length of the message
                    msgLen = BitConverter.ToInt32(data, 4);

                    Message = msgLen > 0 ? Encoding.UTF8.GetString(data, 8, msgLen) : null;

                    break;
                case Command.User:
                    //The next four store the length of the message json
                    msgLen = BitConverter.ToInt32(data, 4);

                    Message = msgLen > 0 ? Encoding.UTF8.GetString(data, 8, msgLen) : null;
                    break;
                case Command.FindGame:
                    //The next four store the length of the name
                    nameLen = BitConverter.ToInt32(data, 4);

                    Name = nameLen > 0 ? Encoding.UTF8.GetString(data, 8, nameLen) : null;

                    break;
                case Command.GameFound:
                    //The next four store the length of the message json
                    msgLen = BitConverter.ToInt32(data, 4);

                    Message = msgLen > 0 ? Encoding.UTF8.GetString(data, 8, msgLen) : null;
                    break;
                case Command.Ready:
                    //The next four store the length of the message json
                    msgLen = BitConverter.ToInt32(data, 4);

                    Message = msgLen > 0 ? Encoding.UTF8.GetString(data, 8, msgLen) : null;
                    break;
                case Command.StartGame:
                    break;
                case Command.Shot:
                    X = BitConverter.ToInt32(data, 4);
                    Y = BitConverter.ToInt32(data, 8);
                    break;
                case Command.ShotResult:
                    Cell = (Cell) BitConverter.ToInt32(data, 4);
                    break;
            }
        }

        //Converts the Data structure into an array of bytes
        public byte[] ToByte(object obj = null)
        {
            List<byte> result = new List<byte>();

            //First four are for the Command
            result.AddRange(BitConverter.GetBytes((int)Command));

            User user;
            switch (Command)
            {
                case Command.Login:
                    //Add the length of the name
                    result.AddRange(Name != null ? BitConverter.GetBytes(Name.Length) : BitConverter.GetBytes(0));

                    //Length of the password
                    result.AddRange(Password != null ? BitConverter.GetBytes(Password.Length) : BitConverter.GetBytes(0));

                    //Add the name
                    if (Name != null) result.AddRange(Encoding.UTF8.GetBytes(Name));

                    //And, lastly we add the message text to our array of bytes
                    if (Password != null) result.AddRange(Encoding.UTF8.GetBytes(Password));

                    break;
                case Command.Message:
                    //Add the length of the name
                    result.AddRange(Name != null ? BitConverter.GetBytes(Name.Length) : BitConverter.GetBytes(0));

                    //Length of the message
                    result.AddRange(Message != null ? BitConverter.GetBytes(Message.Length) : BitConverter.GetBytes(0));

                    //Add the name
                    if (Name != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Name));

                    //And, lastly we add the message text to our array of bytes
                    if (Message != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Message));
                    break;
                case Command.Logout:
                    //Add the length of the name
                    result.AddRange(Name != null ? BitConverter.GetBytes(Name.Length) : BitConverter.GetBytes(0));

                    //Add the name
                    if (Name != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Name));
                    break;
                case Command.Error:
                    //Add the length of the name
                    result.AddRange(Message != null ? BitConverter.GetBytes(Message.Length) : BitConverter.GetBytes(0));

                    //Add the message
                    if (Message != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Message));
                    break;
                case Command.User:
                    //Add the length of the user json
                    user = obj as User;
                    if (user != null) Message = user.ToJson();

                    result.AddRange(Message != null ? BitConverter.GetBytes(Message.Length) : BitConverter.GetBytes(0));

                    //Add the message
                    if (Message != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Message));
                    break;

                case Command.FindGame:
                    //Add the length of the name
                    result.AddRange(Name != null ? BitConverter.GetBytes(Name.Length) : BitConverter.GetBytes(0));

                    //Add the name
                    if (Name != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Name));

                    break;

                case Command.GameFound:
                    // Opponent info
                    user = obj as User;
                    if (user != null) Message = user.ToJson();

                    result.AddRange(Message != null ? BitConverter.GetBytes(Message.Length) : BitConverter.GetBytes(0));

                    //Add the message
                    if (Message != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Message));
                    break;
                case Command.Ready:
                    var board = obj as Board;
                    if (board != null) Message = board.ToJson();

                    result.AddRange(Message != null ? BitConverter.GetBytes(Message.Length) : BitConverter.GetBytes(0));

                    //Add the message
                    if (Message != null)
                        result.AddRange(Encoding.UTF8.GetBytes(Message));
                    break;
                case Command.StartGame:
                    break;
                case Command.Shot:
                    result.AddRange(BitConverter.GetBytes(X));
                    result.AddRange(BitConverter.GetBytes(Y));
                    break;
                case Command.ShotResult:
                    result.AddRange(BitConverter.GetBytes((int)Cell));
                    break;
            }

            return result.ToArray();
        }

        public string Name;      //name by which the client logs into the room
        public string Password;
        public string Message;   //Message text
        public User User;
        public Command Command;  //Command type (login, logout, send message, etcetera)
        public int X;
        public int Y;
        public Cell Cell;
    }
}
