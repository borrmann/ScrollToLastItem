using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollToLastItem
{
    public class Message
    { 
        public required string Text { get; init; }
        public required bool FromMe { get; init; }    
        public required DateTime DateTime { get; init; }

        public string DateGroup
        {
            get
            {
                if (DateTime.Date == DateTime.Now.Date)
                {
                    return "Today";
                }
                else
                {
                    if (DateTime.Date == DateTime.Now.Date.AddDays(-1))
                    {
                        return "Yesterday";
                    }
                    else if ((DateTime.Now - DateTime).TotalDays < 365)
                    {
                        return DateTime.ToString("dd/MM");
                    }
                    else
                    {
                        return DateTime.ToString("dd/MM/yy");
                    }
                }
            }
        }

    }

    public class MessagesGrouped : List<Message>
    {
        public string Name { get; private set; }

        public MessagesGrouped(string name, List<Message> messages) : base(messages)
        {
            Name = name;
        }
    }
}
