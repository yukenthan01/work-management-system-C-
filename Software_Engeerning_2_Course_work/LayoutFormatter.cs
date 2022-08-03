using Software_Engeerning_2_Course_work.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Engeerning_2_Course_work
{
    class LayoutFormatter
    {
        Panel panelUserSubMenu,panelProjectSubMenu, panelTaskSubMenu, panelSubTaskSubMenu;
        //Panel ;
        public LayoutFormatter()
        {
        }

        public LayoutFormatter(Panel panelUserSubMenu,Panel panelProjectSubMenu,Panel panelTaskSubMenu, Panel panelSubTaskSubMenu)
        {
            this.panelUserSubMenu = panelUserSubMenu;
            this.panelProjectSubMenu = panelProjectSubMenu;
            this.panelTaskSubMenu = panelTaskSubMenu;
            this.panelSubTaskSubMenu = panelSubTaskSubMenu;
            

        }
        //check box changer to listbox project task
        public void addListFromCheckList(CheckedListBox checkedListBox,ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (Object items in checkedListBox.CheckedItems)
            {
                listBox.Items.Add(items.ToString());
            }
        }
        //Textbox clear 
        public void formClear(GroupBox groupBox1)
        {
            
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                    
                }
                if (c is ComboBox)
                {
                    c.Text = "";
                }
                if(c is ListBox)
                {
                    c.Text = "";
                }
            }
        }
        //Form align the center of the dashboard 
        public void formAlign(Form currentForm,string tittle)
        {
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.TopLevel = false;
            currentForm.AutoScroll = false;
            MainDashboard.mainDashboardInstance.MainDashboardPanel.Controls.Clear();
            currentForm.Location = new Point(
            MainDashboard.mainDashboardInstance.MainDashboardPanel.ClientSize.Width / 2 - currentForm.Size.Width / 2,
            MainDashboard.mainDashboardInstance.MainDashboardPanel.ClientSize.Height / 2 - currentForm.Size.Height / 2);
            MainDashboard.mainDashboardInstance.MainDashboardPanel.Anchor = AnchorStyles.None;
            currentForm.Height = MainDashboard.mainDashboardInstance.MainDashboardPanel.Height - 40;
            MainDashboard.mainDashboardInstance.MainDashboardPanel.Controls.Add(currentForm);
            currentForm.Show();

            //Form Dashboard tittle
            MainDashboard.mainDashboardInstance.mainTittle.Text = tittle;
            MainDashboard.mainDashboardInstance.mainTittle.Location = new Point(
            MainDashboard.mainDashboardInstance.panelDashboardTittleGet.ClientSize.Width / 2 - MainDashboard.mainDashboardInstance.mainTittle.Size.Width / 2,
            MainDashboard.mainDashboardInstance.panelDashboardTittleGet.ClientSize.Height / 2 - MainDashboard.mainDashboardInstance.mainTittle.Size.Height / 2);
        }
        //Submenu hide first loding 
        public void customizeDesign()
        {
            panelUserSubMenu.Visible = false;
            panelProjectSubMenu.Visible = false;
            panelTaskSubMenu.Visible = false;
            panelSubTaskSubMenu.Visible = false;
            //panelTeamsSubMenu.Visible = false;
        }
        public void hideSubMenu()
        {
            if (panelUserSubMenu.Visible == true)
                panelUserSubMenu.Visible = false;
            if (panelProjectSubMenu.Visible == true)
                panelProjectSubMenu.Visible = false;
            if (panelTaskSubMenu.Visible == true)
                panelTaskSubMenu.Visible = false;
            if (panelSubTaskSubMenu.Visible == true)
                panelSubTaskSubMenu.Visible = false;
            
        }
        public void showSubMenu(Panel panelSubMenu)
        {
            if (panelSubMenu.Visible == false)
            {
                hideSubMenu();
                panelSubMenu.Visible = true;
            }
            else
            {
                panelSubMenu.Visible = false;
            }
        }
    }
}
