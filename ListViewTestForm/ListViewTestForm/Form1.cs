using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ListViewTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyInit();
        }

        private void MyInit()
        {
            //ListViewItem létrehozása
            ListViewItem lvi = new ListViewItem();

            lvi.Text = "Elsődleges Kulcs1";             //Ez az első oszlop a ListViewban
            lvi.SubItems.Add("Szöveg1");      //... Minden további .add egy új oszlop!
            listView1.Items.Add(lvi);       //Hozzá adjuk a ListViewItem -et a listához!

            //Szemléltetés képpen létrehozok még 1 listViewItem-et
            //Nem lehet 1-nél többször hozzá adni egy ListViewItemet, ezért minden sor egy új "lvi"
            ListViewItem lvi2 = new ListViewItem();
            lvi2.Text = "Elsődleges Kulcs2";
            lvi2.SubItems.Add("Szöveg2");
            listView1.Items.Add(lvi2);

            //FONTOS, hogy ha manuálisan hozzuk létre a ListViewItemet
            //akkor ugyan olyan nevű listát nem lehet 2x hozzá adni
            //listView1.Items.add(lvi)      //<--- Ez a sor hibát dobna ki futási időben! Próbáld ki, vedd le a megjegyzést!
        }

        /*
         * Példaképp létrehozok egy eljárást amivel új listákat lehet hozzá adni 1 parancsal!
         */
         private void AddNewList(List<string> items)
        {
            if (items.Count == 0) return; //Ha üres az items lista, akkor visszatér hogy elkerüljük a hibákat!

            //Létrehozunk egy új ListViewItemet
            ListViewItem lvi = new ListViewItem();
            lvi.Text = items[0];        //Az első elemet hozzá adjuk manuálisan, ez az első oszlop!

            for (int i = 1; i < items.Count; i++)
            { //Minden további elem a listában egy új oszlop lesz
                lvi.SubItems.Add(items[i]);
            }

            //Majd hozzá adjuk a ListView-hoz a ListViewItemet
            listView1.Items.Add(lvi);
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                //létrehozzuk a listát
                List<string> list = new List<string>();

                //feltöltjük az elemeket
                list.Add(keyBox.Text);
                list.Add(textBox.Text);

                //az általunk létrehozott eljárás alapján hozzá adunk egy új ListViewItemet!
                AddNewList(list);
            }
            catch (Exception ex)
            {
                //hiba üzenet arra az esetre, ha valami nem sikerülne!
                MessageBox.Show("Hiba lépett fel, Hibakód: \n" + ex.StackTrace,"Hiba!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
