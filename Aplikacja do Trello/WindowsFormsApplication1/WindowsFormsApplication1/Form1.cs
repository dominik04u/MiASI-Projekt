using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrelloNet;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            Trello trello = new Trello("60ed81368707b667cffe423d2571e00b");
            //var url = trello.GetAuthorizationUrl("WindowsFormApplication1", Scope.ReadWrite);
            trello.Authorize("114eeae331e3af8db4526979a01c2f77108e37ec3967e897d8e769e88a7b8fb2");

            // Get the authenticated member
          
            Member me = trello.Members.Me();
            Console.WriteLine(me.FullName);

            Board theTrelloDevBoard = trello.Boards.WithId("573b2e5609201b4364783c69");
  
            var listToSearch = trello.Lists.WithId("573b2f1e1a81171627a589e8");

            var lists = trello.Lists.ForBoard(theTrelloDevBoard);
            List toList = null;
            foreach (List l in lists)
            {
                if (l.Name == textBox2.Text)
                    toList = l;
            }



            trello.Cards.Add(textBox1.Text, listToSearch);
            




        }
        Card card;
        IEnumerable<Card> card1;
        private void button2_Click(object sender, EventArgs e)
        {
            Trello trello = new Trello("60ed81368707b667cffe423d2571e00b");
            //var url = trello.GetAuthorizationUrl("WindowsFormApplication1", Scope.ReadWrite);
            trello.Authorize("114eeae331e3af8db4526979a01c2f77108e37ec3967e897d8e769e88a7b8fb2");
            Board theTrelloDevBoard = trello.Boards.WithId("573b2e5609201b4364783c69");


            var lists = trello.Lists.ForBoard(theTrelloDevBoard);
            List toList = null;
            foreach (List l in lists)
            {
                if (l.Name == textBox2.Text)
                    toList = l;
            }

            card1 = trello.Cards.ForBoard(theTrelloDevBoard);
            Card to = null;
            foreach (Card c in card1)
            {
                if (c.Name == textBox1.Text)
                    to = c;
            }
            
            to.IdList = toList.Id;
            trello.Cards.Update(to);
            
        }
    }
}
