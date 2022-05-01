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
            Dictionary = new Dictionary<string, List<string>>();
        }

        public string CommandID { get; set; }
        public Dictionary<string, List<string>> Dictionary { get; set; }

        //KEYS (1)
        public List<string> GetAllKeys()
        {
            List<string> keyList = new List<string>(Dictionary.Keys);
            return keyList;
        }

        //MEMBERS (2) validate key
        public List<string> GetMembersByKey(string key)
        {
          List<string> lst = Dictionary[key].ToList<string>();
            return lst;
        }

        //ADD (3) validate key
        public void Add(string key, List<string> value)
        {
            Dictionary.Add(key, value);
        }

        //REMOVE (4) validate key
        public void RemoveMember(string key, string member)
        {
                List<string> lst = Dictionary[key];
                lst.RemoveAll((x) => x.Trim() == (member).Trim());
            if (lst.Count == 0)
                Dictionary.Remove(key);
            else
                Dictionary[key] = lst;
        }

        //REMOVEALL (5) validate key
        public void RemoveAll(string key)
        {
            Dictionary.Remove(key);
        }

        //CREAR (6)
        public void Clear()
        {
                Dictionary.Clear();
        }

        public bool KeyExists(string key)
        {
            if (Dictionary == null || Dictionary.Count == 0) return false;
            return Dictionary.ContainsKey(key);
        }
        public bool MemberExists(string key, string member)
        {
            if (Dictionary == null || Dictionary.Count == 0) return false;
            List<string> lst = Dictionary[key].ToList<string>();
            return lst.Contains(member);
        }
    }

        class Program
        {
            static void Main(string[] args)
            {
            bool bError = false;
            string sKey;
            List<string> lstValue = new List<string>();

            MVDictionary md = new MVDictionary();
            while (true)
            {
               if (!bError)
                {
                    Console.Write("\n\rSelect Command Key: \r\n   KEYS (1), MEMBERS (2), ADD (3), REMOVE (4),");
                    Console.Write("REMOVEALL (6), CLEAR (7)? ");
                    md.CommandID = Console.ReadLine().ToString();
                }

                switch (md.CommandID)
                {
                    
                    case "1": //KEYS
                        Console.Write("KEYS: ");
                        
                        if (md.Dictionary.Count == 0)
                        {
                            Console.WriteLine("Error: Keys are not exist!");
                        }
                        else
                        {
                            List<string> kLst = md.GetAllKeys();
                            foreach (var item in kLst)
                            {
                                Console.Write("\n\r  > " + item);
                            }
                        }
                        break;
                    case "2": //MEMBERS
                        Console.Write("MEMBERS set Key: ");
                        sKey = Console.ReadLine().ToString();
                        if (!md.KeyExists(sKey))
                        {
                            Console.WriteLine("Error: Key '{0}' not exists!", sKey);
                        }
                        else
                        {
                            List<string> mLst = md.GetMembersByKey(sKey);

                            foreach (var item in mLst)
                            {
                                Console.Write("\n\r  > " + item);
                            }
                        }
                        break;

                    case "4": //REMOVE
                        Console.Write("REMOVE set Key :");
                        sKey = Console.ReadLine().ToString();
                        if (!md.KeyExists(sKey))
                        {
                            Console.WriteLine("Error: Key '{0}' not exists!", sKey);
                        }
                        else
                        {
                            Console.Write("REMOVE set Mamber :");
                           string member = Console.ReadLine().ToString();
                            if (!md.MemberExists(sKey, member))
                            {
                                Console.WriteLine("Error: Member '{0}' not exists for key '{1}'!", member, sKey);
                            }
                            else
                            {
                                md.RemoveMember(sKey, member);
                            }
                        }
                        break;

                    case "6": //REMOVEALL
                        Console.Write("REMOVE set Key :");
                        sKey = Console.ReadLine().ToString();
                        if (!md.KeyExists(sKey))
                        {
                            bError = true;
                            Console.WriteLine("Error: Key '{0}' not exists!", sKey);
                        }
                        else
                        {
                            md.RemoveAll(sKey);
                        }
                       
                        break;


                    case "7":
                        Console.Write("CLEAR Y/N? ");
                        if (Console.ReadLine().ToString() == "Y")
                            md.Clear();
                        break;
             
                    case "3": //ADD 
                        
                            Console.Write("Key to ADD:");
                            sKey = Console.ReadLine().ToString();

                            if (md.KeyExists(sKey))
                            {
                                bError = true;
                                Console.WriteLine("Error: Key '{0}' already exists!", sKey);
                            }

                        if (!bError)
                        {
                            Console.Write("Values comma separated List:");
                            lstValue = Console.ReadLine().ToString().Split(',').ToList<string>();
                        }

                        if (!bError)
                        {
                            md.Add(sKey, lstValue);
                            int c = md.Dictionary.Count;
                            bError = false;
                        }
                        break;
                }
             }
          }
       }
    }

