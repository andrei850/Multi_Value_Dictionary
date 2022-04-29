using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public class MVDictionary
    {
        public MVDictionary()
        {
            Dictionary = new Dictionary<string, string>();
            Key = "";
            Value = "";
        }

        public string Key { get; set; }
        public string Value { get; set; }
        public string CommandID { get; set; }
        public Dictionary<string, string> Dictionary { get; set; }

        public void AddMember(string key, string valuy)
        {
            Dictionary.Add(key, valuy);
        }
        public void RemoveMember(string key)
        {
            Dictionary.Remove(key);
        }
        public bool ValidateKey(string key)
        {
            if (Dictionary.Count == 0) return false;//No errors if cout 0
            return Dictionary.ContainsKey(key);
        }

        public bool ValidateValue(string value)
        {
            if (Dictionary.Count == 0) return false; //No errors if cout 0
            return Dictionary.Any(b => (b.Value != null && b.Value == value));
        }

        public string GetAllKeys()
        {
            string allKeys = "";
            foreach (var item in Dictionary)
            {
                if (allKeys == "")
                allKeys = item.Key;
                else allKeys = allKeys + ", " + item.Key;

            }
            return allKeys;
        }
        public string GetMembersByKey(string key)
        {
            string members = "";
            if (!KeyExists(key))
            {
                members = "ERROR: key not exists!";
            }
            else {
                foreach (var item in Dictionary)
                {
                    if (item.Key == key)
                    {
                        if (members == "")
                            members = item.Key + ":" + item.Value + "\r\n";
                        else members = members + item.Key + ":" + item.Value + "\r\n";
                    }
                }
            }
           
            return members;
        }

        public string GetMembersByValue(string value)
        {

            string members = "";
            foreach (var item in Dictionary)
                {
                    if (item.Value == value)
                    {
                        if (members == "")
                            members = item.Key + ":" + item.Value + "\r\n";
                        else members = members + item.Key + ":" + item.Value + "\r\n";
                    }
                }

            return members;
        }

        public string GetAllMembers()
        {
            string allMembers = "";
            

                foreach (var item in Dictionary)
                {
                    if (allMembers == "")
                        allMembers = item.Key + ":" + item.Value + "\r\n";
                    else allMembers = allMembers + item.Key + ":" + item.Value + "\r\n";

                }
           
            return allMembers;
        }

        public bool KeyExists(string key)
        {
              return  Dictionary.ContainsKey(key);
        }
        public void Clear()
        {
                Dictionary.Clear();
        }
    }

        class Program
        {
            static void Main(string[] args)
            {
            bool bError = false;
            //bool addKey = true;
            //bool addValue = true;
            //bool askKeyQestion = true;
            //bool askValueQestion = true;

            MVDictionary md = new MVDictionary();
            while (true)
            {
                if (!bError)
                {
                    Console.Write("\n\rSelect Command Key: \r\n   KEYS (1), MEMBERS (2), ADD (3), REMOVE (4),");
                    Console.Write("REMOVEALL (6), CLEAR (7), \r\n   KEYEXISTS (9), MEMBEREXISTS (10), ALLMEMBERS (11)? ");
                    md.CommandID = Console.ReadLine().ToString();
                }

                switch (md.CommandID)
                {
                    case "1":
                        Console.Write("All KEYS: " + md.GetAllKeys());
                        break;
                    case "2":
                        Console.Write("MEMBERS by Key: ");
                        Console.Write(md.GetMembersByKey(Console.ReadLine().ToString()));
                        break;
                    case "4":
                        Console.Write("REMOVE by Key :");
                        md.Key = Console.ReadLine().ToString();
                        md.RemoveMember(md.Key);
                        break;
                    case "7":
                        Console.Write("CLEAR Y/N? ");
                        if (Console.ReadLine().ToString() == "Y")
                            md.Clear();
                        break;
                    case "9":
                            Console.Write("KEYEXISTS set Key: ");
                            Console.Write(md.GetMembersByKey(Console.ReadLine().ToString()));
                        break;
                    case "10":
                        Console.Write("MEMBEREXISTS set Key: ");
                        Console.Write(md.GetMembersByValue(Console.ReadLine().ToString()));
                        break;
                    case "11":
                        Console.Write("All MEMBERS: \r\n" + md.GetAllMembers());
                        break;
                    case "3":
                        if (md.Key == "")
                        {
                            Console.Write("Key to ADD:");
                            md.Key = Console.ReadLine().ToString();

                            if (md.ValidateKey(md.Key))
                            {
                                bError = true;
                                Console.WriteLine("Error: Key '{0}' is not unique!", md.Key);
                                md.Key = "";

                            }
                        }

                        if (md.Key != "" && md.Value == "")
                        {
                            Console.Write("Value:");
                            md.Value = Console.ReadLine().ToString();


                            if (md.ValidateValue(md.Value))
                            {
                                bError = true;
                                Console.WriteLine("Error: Value '{0}' is not unique!", md.Value);
                                md.Value = "";
                            }
                            
                        }

                        if (md.Key != "" && md.Value != "")
                        {
                            md.AddMember(md.Key, md.Value);
                            int c = md.Dictionary.Count;
                            Console.WriteLine("You entered '{0}' : '{1}'", md.Key, md.Value);
                            md.Key = "";
                            md.Value = "";
                            bError = false;
                        }
                        break;
                }
            }
          }
        }
    }

