using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7
{
    class GameInfo
    {
        private string _title;
        private string _developer;
        private string _publisher;
        private string _rank;
        private int _rankValue;

        public string title {
            get { return _title; }
            set { _title = value; }
        }

        public string developer {
            get { return _developer; }
            set { _developer = value;}
        }

        public string publisher {
            get { return _publisher; }
            set { _publisher = value; }
        }
       
        public string  rank {
            get { return _rank; }
            set { _rank = value;
                _rankValue = _rank switch { "A" => 80, "B" => 60, "C" => 40, "D" => 20, _ => 50 };
                    
            }
        }

        public int rankValue {
            get { return _rankValue ; }
        }

        public GameInfo()
        {
        }

        public GameInfo(string title,string developer,string publisher,string rank)
        {
            this.title = title;
            this.developer = developer;
            this.publisher = publisher;
            this.rank = rank;
                
        }
    }
}
