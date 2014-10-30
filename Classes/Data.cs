using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        List,       //Get a list of users in the chat room from the server
        Null        //No command
    }

    //The data structure by which the server and the client interact with 
    //each other
    class Data
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
            }
        }

        //Converts the Data structure into an array of bytes
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //First four are for the Command
            result.AddRange(BitConverter.GetBytes((int)Command));

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
            }

            return result.ToArray();
        }

        public string Name;      //Name by which the client logs into the room
        public string Password;
        public string Message;   //Message text
        public Command Command;  //Command type (login, logout, send message, etcetera)
    }
}
