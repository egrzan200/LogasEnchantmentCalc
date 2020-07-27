using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enchantmentCalculator
{
    public partial class Form1 : Form
    {
        public int time;
        public string prepTime;
        public int enchantmentMultiplier;
        public int quantityMultiplier;
        public int timeQuality;
        public int timePower;
        public int[] selectedQuality = new int[9];
        public int[] selectedPower = new int[11];
        public int additionalPoints;

        public Form1()
        {
            InitializeComponent();
            time = 0;
            prepTime = "No Prep";
            enchantmentMultiplier = 1;
            quantityMultiplier = 1;
            timeQuality = 5;
            timePower = 10;
            timeTextBox.Text = "Prep time: " + prepTime + " || Work time: " + time;
            SelectTiedToPower.SelectedIndex = 0;
            selectPower8.SelectedIndex = 0;
            selectPower9.SelectedIndex = 0;
            Level3.Enabled = false;
            Level4.Enabled = false;
            Level5.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void label17_Click(object sender, EventArgs e) { }
        private void selectQuality1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ShapeMaterial_Click(object sender, EventArgs e) { }

        
        private void Empowerment_CheckedChanged(object sender, EventArgs e) 
        {
            if (Empowerment.Checked)
            {
                enchantmentMultiplier = 1;
                if (Enchantment.Checked)
                {
                    prepTime = "30 Minutes";
                    timeQuality = 10;
                    timePower = 60;
                }
                else if (AdvEnchantment.Checked)
                {
                    prepTime = "15 Minutes";
                    timeQuality = 5;
                    timePower = 30;
                }
                else if (ExalEnchantment.Checked)
                {
                    prepTime = "10 Minutes";
                    timeQuality = 2;
                    timePower = 15;
                }
                
                //MessageBox.Show(prepTime);
                QuantityPanel.Enabled = true;
                updateTime();
            }
            else if (!ShapeMaterial.Checked)
            {
                QuantityRadio1.Checked = true;
                QuantityPanel.Enabled = false;
                updateTime();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) 
        {
            if (ShapeMaterial.Checked)
            {
                prepTime = "No Prep";
                enchantmentMultiplier = 1;
                if (Enchantment.Checked)
                {
                    timeQuality = 5;
                    timePower = 10;
                }
                else if (AdvEnchantment.Checked)
                {
                    timeQuality = 2;
                    timePower = 5;
                }
                else if (ExalEnchantment.Checked)
                {
                    timeQuality = 1;
                    timePower = 2;
                }
                //MessageBox.Show(prepTime);
                QuantityPanel.Enabled = true;
                updateTime();
            }
            else if(!Empowerment.Checked)
            {
                QuantityRadio1.Checked = true;
                QuantityPanel.Enabled = false;
                updateTime();
            }
        }

        private void updateTime()
        {
            int qualityTime = 0;
            int powerTime = 0;
            for(int i = 0; i < selectedQuality.Length; i++)
            {
                qualityTime = qualityTime + (timeQuality * selectedQuality[i]);
            }
            for(int j = 0; j < selectedPower.Length; j++)
            {
                powerTime = powerTime + (timePower * selectedPower[j]);
            }

            powerTime = powerTime + (additionalPoints * timePower);
            time = (qualityTime + powerTime);
            time = ((time * enchantmentMultiplier) * quantityMultiplier);

            int itemTime = time;

           if(comboBox1.SelectedIndex == 0)
            {
                itemTime = time;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                itemTime = (int)(time * 0.90);
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                itemTime = (int)(time * 0.75);
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                itemTime = (int)(time * 0.50);
            }

            int days = (itemTime / 1440);
            int hours = ((itemTime % 1440) / 60);
            int mins = (itemTime % 60);

            timeTextBox.Text = "Prep time: " + prepTime + " || Work time: " + days + " Days " + hours + " Hours " + mins + " Minutes ";
        }

        private void Level1_CheckedChanged(object sender, EventArgs e)
        {
            if (Level1.Checked)
            {
                prepTime = "12 hours";
                enchantmentMultiplier = 1;
                timeQuality = 60;
                timePower = 1440;
                updateTime();
                //MessageBox.Show(prepTime);
            }
        }

        private void Level2_CheckedChanged(object sender, EventArgs e)
        {
            if (Level2.Checked)
            {
                prepTime = "1 Day";
                enchantmentMultiplier = 2;
                timeQuality = 60;
                timePower = 1440;
                updateTime();
                //MessageBox.Show(prepTime);
            }
        }

        private void Level3_CheckedChanged(object sender, EventArgs e)
        {
            if (Level3.Checked)
            {
                prepTime = "2 Days";
                enchantmentMultiplier = 4;
                timeQuality = 60;
                timePower = 1440;
                updateTime();
                //MessageBox.Show(prepTime);
            }
        }

        private void Level4_CheckedChanged(object sender, EventArgs e)
        {
            if (Level4.Checked)
            {
                prepTime = "4 Days";
                enchantmentMultiplier = 8;
                timeQuality = 60;
                timePower = 1440;
                updateTime();
                //MessageBox.Show(prepTime);
            }
        }
        private void Level5_CheckedChanged(object sender, EventArgs e)
        {
            if (Level5.Checked)
            {
                prepTime = "7 Days";
                enchantmentMultiplier = 16;
                timeQuality = 60;
                timePower = 1440;
                updateTime();
                //MessageBox.Show(prepTime);
            }

        }

        private void QuantityRadio1_CheckedChanged(object sender, EventArgs e)
        {
            if (QuantityRadio1.Checked)
            {
                quantityMultiplier = 1;
                updateTime();
            }
        }

        private void QuantityRadio2_CheckedChanged(object sender, EventArgs e)
        {
            if (QuantityRadio2.Checked)
            {
                quantityMultiplier = 2;
                updateTime();
            }
        }

        private void QuantityRadio3_CheckedChanged(object sender, EventArgs e)
        {
            if (QuantityRadio3.Checked)
            {
                quantityMultiplier = 3;
                updateTime();
            }
        }

        private void QuantityRadio4_CheckedChanged(object sender, EventArgs e)
        {
            if (QuantityRadio4.Checked)
            {
                quantityMultiplier = 4;
                updateTime();
            }
        }

        private void QuantityRadio5_CheckedChanged(object sender, EventArgs e)
        {
            if (QuantityRadio5.Checked)
            {
                quantityMultiplier = 5;
                updateTime();
            }
        }

        private void QuantityRadio6_CheckedChanged(object sender, EventArgs e)
        {
            if (QuantityRadio6.Checked)
            {
                quantityMultiplier = 6;
                updateTime();
            }
        }

        
        private void selectQuality1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (selectQuality1.SelectedIndex == 0)
            {
                selectedQuality[0] = 0;
            }else if(selectQuality1.SelectedIndex == 1)
            {
                selectedQuality[0] = 1;
            }
            else if (selectQuality1.SelectedIndex == 2)
            {
                selectedQuality[0] = 2;
            }
            else if (selectQuality1.SelectedIndex == 3)
            {
                selectedQuality[0] = 4;
            }

            updateTime();
        }

        private void selectQuality2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality2.SelectedIndex == 0)
            {
                selectedQuality[1] = 0;
            }
            else if (selectQuality2.SelectedIndex == 1)
            {
                selectedQuality[1] = 1;
            }
            else if (selectQuality2.SelectedIndex == 2)
            {
                selectedQuality[1] = 2;
            }
            else if (selectQuality2.SelectedIndex == 3)
            {
                selectedQuality[1] = 4;
            }

            updateTime();
        }

        private void selectQuality3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality3.SelectedIndex == 0)
            {
                selectedQuality[2] = 0;
            }
            else if (selectQuality3.SelectedIndex == 1)
            {
                selectedQuality[2] = 1;
            }
            else if (selectQuality3.SelectedIndex == 2)
            {
                selectedQuality[2] = 2;
            }
            else if (selectQuality3.SelectedIndex == 3)
            {
                selectedQuality[2] = 4;
            }

            updateTime();
        }

        private void selectQuality4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality4.SelectedIndex == 0)
            {
                selectedQuality[3] = 0;
            }
            else if (selectQuality4.SelectedIndex == 1)
            {
                selectedQuality[3] = 1;
            }
            else if (selectQuality4.SelectedIndex == 2)
            {
                selectedQuality[3] = 2;
            }
            else if (selectQuality4.SelectedIndex == 3)
            {
                selectedQuality[3] = 4;
            }

            updateTime();
        }

        private void selectQuality5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality5.SelectedIndex == 0)
            {
                selectedQuality[4] = 0;
            }
            else if (selectQuality5.SelectedIndex == 1)
            {
                selectedQuality[4] = 1;
            }
            else if (selectQuality5.SelectedIndex == 2)
            {
                selectedQuality[4] = 2;
            }
            else if (selectQuality5.SelectedIndex == 3)
            {
                selectedQuality[4] = 4;
            }

            updateTime();
        }

        private void selectQuality6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality6.SelectedIndex == 0)
            {
                selectedQuality[5] = 0;
            }
            else if (selectQuality6.SelectedIndex == 1)
            {
                selectedQuality[5] = 1;
            }
            else if (selectQuality6.SelectedIndex == 2)
            {
                selectedQuality[5] = 2;
            }
            else if (selectQuality6.SelectedIndex == 3)
            {
                selectedQuality[5] = 4;
            }

            updateTime();
        }

        private void selectQuality7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality7.SelectedIndex == 0)
            {
                selectedQuality[6] = 0;
            }
            else if (selectQuality7.SelectedIndex == 1)
            {
                selectedQuality[6] = 1;
            }
            else if (selectQuality7.SelectedIndex == 2)
            {
                selectedQuality[6] = 2;
            }
            else if (selectQuality7.SelectedIndex == 3)
            {
                selectedQuality[6] = 4;
            }

            updateTime();
        }

        private void selectQuality8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality8.SelectedIndex == 0)
            {
                selectedQuality[7] = 0;
            }
            else if (selectQuality8.SelectedIndex == 1)
            {
                selectedQuality[7] = 1;
            }
            else if (selectQuality8.SelectedIndex == 2)
            {
                selectedQuality[7] = 2;
            }
            else if (selectQuality8.SelectedIndex == 3)
            {
                selectedQuality[7] = 4;
            }

            updateTime();
        }

        private void selectQuality9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectQuality9.SelectedIndex == 0)
            {
                selectedQuality[8] = 0;
            }
            else if (selectQuality9.SelectedIndex == 1)
            {
                selectedQuality[8] = 1;
            }
            else if (selectQuality9.SelectedIndex == 2)
            {
                selectedQuality[8] = 2;
            }
            else if (selectQuality9.SelectedIndex == 3)
            {
                selectedQuality[8] = 4;
            }

            updateTime();
        }

        private void selectPower1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower1.SelectedIndex == 0)
            {
                selectedPower[0] = 0;
            }
            else if (selectPower1.SelectedIndex == 1)
            {
                selectedPower[0] = 1;
            }
            else if (selectPower1.SelectedIndex == 2)
            {
                selectedPower[0] = 2;
            }
            else if (selectPower1.SelectedIndex == 3)
            {
                selectedPower[0] = 4;
            }

            updateTime();
        }

        private void selectPower2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower2.SelectedIndex == 0)
            {
                selectedPower[1] = 0;
            }
            else if (selectPower2.SelectedIndex == 1)
            {
                selectedPower[1] = 1;
            }
            else if (selectPower2.SelectedIndex == 2)
            {
                selectedPower[1] = 2;
            }
            else if (selectPower2.SelectedIndex == 3)
            {
                selectedPower[1] = 4;
            }

            updateTime();
        }

        private void selectPower3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower3.SelectedIndex == 0)
            {
                selectedPower[2] = 0;
            }
            else if (selectPower3.SelectedIndex == 1)
            {
                selectedPower[2] = 1;
            }
            else if (selectPower3.SelectedIndex == 2)
            {
                selectedPower[2] = 2;
            }
            else if (selectPower3.SelectedIndex == 3)
            {
                selectedPower[2] = 4;
            }

            updateTime();
        }

        private void selectPower4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower4.SelectedIndex == 0)
            {
                selectedPower[3] = 0;
            }
            else if (selectPower4.SelectedIndex == 1)
            {
                selectedPower[3] = 1;
            }
            else if (selectPower4.SelectedIndex == 2)
            {
                selectedPower[3] = 2;
            }
            

            updateTime();
        }

        private void selectPower5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower5.SelectedIndex == 0)
            {
                selectedPower[4] = 0;
            }
            else if (selectPower5.SelectedIndex == 1)
            {
                selectedPower[4] = 1;
            }
            else if (selectPower5.SelectedIndex == 2)
            {
                selectedPower[4] = 2;
            }
            else if (selectPower5.SelectedIndex == 3)
            {
                selectedPower[4] = 4;
            }

            updateTime();
        }

        private void selectPower6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower6.SelectedIndex == 0)
            {
                selectedPower[5] = 0;
            }
            else if (selectPower6.SelectedIndex == 1)
            {
                selectedPower[5] = 1;
            }
            else if (selectPower6.SelectedIndex == 2)
            {
                selectedPower[5] = 2;
            }
            

            updateTime();
        }

        private void selectPower7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower7.SelectedIndex == 0)
            {
                selectedPower[6] = 0;
            }
            else if (selectPower7.SelectedIndex == 1)
            {
                selectedPower[6] = 1;
            }
            else if (selectPower7.SelectedIndex == 2)
            {
                selectedPower[6] = 2;
            }
            else if (selectPower7.SelectedIndex == 3)
            {
                selectedPower[6] = 4;
            }

            updateTime();
        }

        private void selectPower8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower8.SelectedIndex == 0)
            {
                selectedPower[7] = 0;
            }
            else if (selectPower8.SelectedIndex == 1)
            {
                selectedPower[7] = 5;
            }
            else if (selectPower8.SelectedIndex == 2)
            {
                selectedPower[7] = 10;
            }

            updateTime();
        }

        private void selectPower9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectPower9.SelectedIndex == 0)
            {
                selectedPower[8] = 0;
            }
            else if (selectPower9.SelectedIndex == 1)
            {
                selectedPower[8] = 1;
            }
            else if (selectPower9.SelectedIndex == 2)
            {
                selectedPower[8] = 2;
            }
            else if (selectPower9.SelectedIndex == 3)
            {
                selectedPower[8] = 4;
            }

            updateTime();
        }

        private void SelectTiedToPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectTiedToPower.SelectedIndex == 0)
            {
                selectedPower[9] = 0;
            }
            else if (SelectTiedToPower.SelectedIndex == 1)
            {
                selectedPower[9] = 1;
            }
            else if (SelectTiedToPower.SelectedIndex == 2)
            {
                selectedPower[9] = 2;
            }
            else if (SelectTiedToPower.SelectedIndex == 3)
            {
                selectedPower[9] = 4;
            }

            updateTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the help menu! \n\nFirst select the level of enchantment you would like to do. Afterwards chose the different qualities and powers. If the enchantment doesn't have a level in its name, you are able to create multiple copies by using a multiplier shown in the quantity radio buttons. \n\nThe '+' button clears the field, but keeps the points that are used for the calculation. This means you can have multiple of this quality in one item. \n\nThe restart button clears all of the calculations and allows you to start calculations again");
        }

        private void additionalControl_Click(object sender, EventArgs e)
        {
            if (selectPower9.SelectedIndex == 0)
            {
                MessageBox.Show("Please select at least one level of the enchantment on the left to this button");
            }
            else if (selectPower9.SelectedIndex == 1)
            {
                additionalPoints = additionalPoints + 1;
                selectPower9.SelectedIndex = 0;
            }
            else if (selectPower9.SelectedIndex == 2)
            {
                additionalPoints = additionalPoints + 2;
                selectPower9.SelectedIndex = 0;
            }
            else if (selectPower9.SelectedIndex == 3)
            {
                additionalPoints = additionalPoints + 4;
                selectPower9.SelectedIndex = 0;
            }
            updateTime();
        }

        private void additionalTransferal_Click(object sender, EventArgs e)
        {
            if (selectPower8.SelectedIndex == 0)
            {
                MessageBox.Show("Please select at least one level of the enchantment on the left to this button");
            }
            else if (selectPower8.SelectedIndex == 1)
            {
                additionalPoints = additionalPoints + 5;
                selectPower8.SelectedIndex = 0;
            }
            else if (selectPower8.SelectedIndex == 2)
            {
                additionalPoints = additionalPoints + 10;
                selectPower8.SelectedIndex = 0;
            }
            
            updateTime();
        }

        private void additionalTie_Click(object sender, EventArgs e)
        {
            if (SelectTiedToPower.SelectedIndex == 0)
            {
                MessageBox.Show("Please select at least one level of the enchantment on the left to this button");
            }
            else if (SelectTiedToPower.SelectedIndex == 1)
            {
                additionalPoints = additionalPoints + 1;
                SelectTiedToPower.SelectedIndex = 0;
            }
            else if (SelectTiedToPower.SelectedIndex == 2)
            {
                additionalPoints = additionalPoints + 2;
                SelectTiedToPower.SelectedIndex = 0;
            }else if (SelectTiedToPower.SelectedIndex == 3)
            {
                additionalPoints = additionalPoints + 4;
                SelectTiedToPower.SelectedIndex = 0;
            }

            updateTime();
        }

        private void restartbtn_Click(object sender, EventArgs e)
        {
            additionalPoints = 0;

            selectPower1.SelectedIndex = 0;
            selectPower2.SelectedIndex = 0;
            selectPower3.SelectedIndex = 0;
            selectPower4.SelectedIndex = 0;
            selectPower5.SelectedIndex = 0;
            selectPower6.SelectedIndex = 0;
            selectPower7.SelectedIndex = 0;
            selectPower8.SelectedIndex = 0;
            selectPower9.SelectedIndex = 0;
            SelectTiedToPower.SelectedIndex = 0;

            selectQuality1.SelectedIndex = 0;
            selectQuality2.SelectedIndex = 0;
            selectQuality3.SelectedIndex = 0;
            selectQuality4.SelectedIndex = 0;
            selectQuality5.SelectedIndex = 0;
            selectQuality6.SelectedIndex = 0;
            selectQuality7.SelectedIndex = 0;
            selectQuality8.SelectedIndex = 0;
            selectQuality9.SelectedIndex = 0;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            ShapeMaterial.Checked = true;
            QuantityRadio1.Checked = true;
        }

        private void Enchantment_CheckedChanged(object sender, EventArgs e)
        {
            if (Enchantment.Checked)
            {
                Level3.Enabled = false;
                Level4.Enabled = false;
                Level5.Enabled = false;
            }

            if (ShapeMaterial.Checked)
            {
                prepTime = "No Prep";
                timeQuality = 5;
                timePower = 10;
            }
            else if (Empowerment.Checked)
            {
                prepTime = "30 Minutes";
                timeQuality = 10;
                timePower = 60;
            }
            updateTime();
        }

        private void AdvEnchantment_CheckedChanged(object sender, EventArgs e)
        {
            if (AdvEnchantment.Checked)
            {
                Level3.Enabled = true;
                Level4.Enabled = true;
                Level5.Enabled = false;
            }

            if (ShapeMaterial.Checked)
            {
                prepTime = "No Prep";
                timeQuality = 2;
                timePower = 5;
            }
            else if (Empowerment.Checked)
            {
                prepTime = "15 Minutes";
                timeQuality = 5;
                timePower = 30;
            }
            updateTime();
        }

        private void ExalEnchantment_CheckedChanged(object sender, EventArgs e)
        {
            if (ExalEnchantment.Checked)
            {
                Level3.Enabled = true;
                Level4.Enabled = true;
                Level5.Enabled = true;

                if (ShapeMaterial.Checked)
                {
                    prepTime = "No Prep";
                    timeQuality = 1;
                    timePower = 2;
                }else if (Empowerment.Checked){
                    prepTime = "10 Minutes";
                    timeQuality = 2;
                    timePower = 15;
                }
                updateTime();
            }
        }

        private void label24_Click(object sender, EventArgs e){}

        private void Form1_Load(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){ updateTime(); }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                selectedPower[10] = 0;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                selectedPower[10] = 1;
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                selectedPower[10] = 2;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                selectedPower[10] = 4;
            }

            updateTime();
        }
    }
}
