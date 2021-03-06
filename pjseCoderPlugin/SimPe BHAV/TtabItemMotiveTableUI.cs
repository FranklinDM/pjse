/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for TtabItemMotiveTableUI.
	/// </summary>
	public class TtabItemMotiveTableUI : System.Windows.Forms.UserControl
	{
		#region Form variables

        private System.Windows.Forms.Label lbMotive0;
		private System.Windows.Forms.Label lbMotive1;
		private System.Windows.Forms.Label lbMotive2;
		private System.Windows.Forms.Label lbMotive3;
		private System.Windows.Forms.Label lbMotive4;
		private System.Windows.Forms.Label lbMotive5;
		private System.Windows.Forms.Label lbMotive6;
		private System.Windows.Forms.Label lbMotive7;
		private System.Windows.Forms.Label lbMotive9;
		private System.Windows.Forms.Label lbMotive11;
		private System.Windows.Forms.Label lbMotive8;
		private System.Windows.Forms.Label lbMotive10;
		private System.Windows.Forms.Label lbMotive14;
		private System.Windows.Forms.Label lbMotive15;
		private System.Windows.Forms.Label lbMotive13;
		private System.Windows.Forms.Label lbMotive12;
        private System.Windows.Forms.Panel pnAllGroups;
		private System.Windows.Forms.CheckBox cbShowAll;
		private System.Windows.Forms.Panel pnCopyButtons;
		private System.Windows.Forms.Button btnCpyM0;
		private System.Windows.Forms.Button btnCpyM1;
		private System.Windows.Forms.Button btnCpyM2;
		private System.Windows.Forms.Button btnCpyM3;
		private System.Windows.Forms.Button btnCpyM4;
		private System.Windows.Forms.Button btnCpyM5;
		private System.Windows.Forms.Button btnCpyM7;
		private System.Windows.Forms.Button btnCpyM6;
		private System.Windows.Forms.Button btnCpyM9;
		private System.Windows.Forms.Button btnCpyM12;
		private System.Windows.Forms.Button btnCpyM11;
		private System.Windows.Forms.Button btnCpyM10;
		private System.Windows.Forms.Button btnCpyM15;
		private System.Windows.Forms.Button btnCpyM14;
		private System.Windows.Forms.Button btnCpyM13;
		private System.Windows.Forms.Button btnCpyM8;
		private System.Windows.Forms.Label lbCBM0;
		private System.Windows.Forms.Label lbCBM1;
		private System.Windows.Forms.Label lbCBM2;
		private System.Windows.Forms.Label lbCBM3;
		private System.Windows.Forms.Label lbCBM4;
		private System.Windows.Forms.Label lbCBM5;
		private System.Windows.Forms.Label lbCBM6;
		private System.Windows.Forms.Label lbCBM7;
		private System.Windows.Forms.Label lbCBM15;
		private System.Windows.Forms.Label lbCBM11;
		private System.Windows.Forms.Label lbCBM14;
		private System.Windows.Forms.Label lbCBM8;
		private System.Windows.Forms.Label lbCBM9;
		private System.Windows.Forms.Label lbCBM13;
		private System.Windows.Forms.Label lbCBM10;
		private System.Windows.Forms.Label lbCBM12;
		private System.Windows.Forms.Button btnCopyAll;
        private Label lbNrGroups;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TtabItemMotiveTableUI()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            pnCopyButtons.Visible = pnAllGroups.Visible = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}



		#region TtabItemMotiveTableUI
        private TtabItemMotiveTable item = null;

		private Button[] aButtons;
        private int maxWidth = 0;

        public TtabItemMotiveTable MotiveTable
        {
            get { return item; }
            set
            {
                if (this.item != value)
                {
                    if (item != null && item.Wrapper != null)
                        item.Wrapper.WrapperChanged -= new System.EventHandler(this.WrapperChanged);
                    this.item = value;
                    setData();
                    if (item != null)
                        item.Wrapper.WrapperChanged += new System.EventHandler(this.WrapperChanged);
                }
            }
        }

        private void WrapperChanged(object sender, System.EventArgs e)
        {
            if (sender != item) return;
            setData();
        }


        private void setData()
        {
            cbShowAll.Enabled = false;
            this.pnAllGroups.Controls.Clear();

            if (item != null && item.Count > 0)
            {
                this.lbNrGroups.Text = (this.lbNrGroups.Text.Split(':')[0]) + ": " + item.Count.ToString();

                TtabMotiveGroupUI c = new TtabMotiveGroupUI();
                c.MotiveGroup = item[0];
                if (item.Type == TtabItemMotiveTableType.Human)
                    c.MGName = pjse.BhavWiz.readStr(pjse.GS.BhavStr.TTABAges, 0);
                else
                    c.MGName = "[0]";
                setLocations(c);

                if (item.Count > 1)
                {
                    cbShowAll.Enabled = true;
                    int nextLeft = 0;
                    for (int i = 1; i < item.Count; i++)
                    {
                        c = new TtabMotiveGroupUI();
                        this.pnAllGroups.Controls.Add(c);
                        c.MotiveGroup = item[i];
                        if (item.Type == TtabItemMotiveTableType.Human)
                            c.MGName = pjse.BhavWiz.readStr(pjse.GS.BhavStr.TTABAges, (ushort)i);
                        else
                            c.MGName = "[" + i.ToString() + "]";
                        c.Location = new Point(nextLeft, 0);
                        nextLeft += c.Width + 2;
                    }
                }
            }
            else
                this.lbNrGroups.Text = (this.lbNrGroups.Text.Split(':')[0]) + ": 0";

            cbShowAll_CheckedChanged(null, null);
        }

        private void setLocations(TtabMotiveGroupUI c)
        {
            Button[] b = {
							 btnCpyM0  ,btnCpyM1  ,btnCpyM2  ,btnCpyM3  ,btnCpyM4  ,btnCpyM5  ,btnCpyM6  ,btnCpyM7
							,btnCpyM8  ,btnCpyM9  ,btnCpyM10 ,btnCpyM11 ,btnCpyM12 ,btnCpyM13 ,btnCpyM14 ,btnCpyM15
							};
            aButtons = b;

            Label[] lbCBM = {
                lbCBM0, lbCBM1, lbCBM2, lbCBM3, lbCBM4, lbCBM5, lbCBM6, lbCBM7
                ,lbCBM8, lbCBM9, lbCBM10, lbCBM11, lbCBM12, lbCBM13, lbCBM14, lbCBM15
            };

            Label[] aMotiveLabels = {
				lbMotive0 ,lbMotive1 ,lbMotive2  ,lbMotive3  ,lbMotive4  ,lbMotive5  ,lbMotive6  ,lbMotive7
				,lbMotive8 ,lbMotive9 ,lbMotive10 ,lbMotive11 ,lbMotive12 ,lbMotive13 ,lbMotive14 ,lbMotive15
			};


            this.Controls.Clear();
            this.Controls.Add(this.cbShowAll);
            this.Controls.Add(this.lbNrGroups);
            this.Controls.Add(this.pnAllGroups);
            this.Controls.Add(this.pnCopyButtons);
            this.Controls.Add(c);

            maxWidth = this.lbNrGroups.Width;

            int cbW = 0;
            for (ushort m = 0; m < aMotiveLabels.Length; m++)
            {
                this.Controls.Add(aMotiveLabels[m]);
                aMotiveLabels[m].Text = pjse.BhavWiz.readStr(pjse.GS.BhavStr.Motives, m);
                if (aMotiveLabels[m].Width > maxWidth) maxWidth = aMotiveLabels[m].Width;
                cbW = b[m].Width;
            }

            for (ushort m = 0; m < aMotiveLabels.Length; m++)
            {
                aMotiveLabels[m].Location = new Point(maxWidth - aMotiveLabels[m].Width, c.Tops[m] + 2);
                aButtons[m].Location = new Point(0, c.Tops[m]);
                lbCBM[m].Location = new Point(cbW + 2, c.Tops[m] + 2);
            }

            this.cbShowAll.Location = new Point(maxWidth - this.cbShowAll.Width, 2);

            c.Location = new Point(maxWidth + 2, 0);
            this.Height = c.Height + 24;

            this.btnCopyAll.Location = new Point(0, c.Tops[15] + c.Tops[1] - c.Tops[0]);
            this.lbNrGroups.Location = new Point(4, this.btnCopyAll.Top + 2);

            this.pnCopyButtons.Anchor = AnchorStyles.None;
            this.pnCopyButtons.Location = new Point(c.Right + 2, 0);
            this.pnCopyButtons.Size = new Size(lbCBM0.Right + 4, this.Height);
            this.pnCopyButtons.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

            this.pnAllGroups.Anchor = AnchorStyles.None;
            this.pnAllGroups.Location = new Point(c.Right + 2, 0);
            this.pnAllGroups.Size = new Size(this.Width - this.pnAllGroups.Left, c.Bottom + 24);
            this.pnAllGroups.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }


        private void doCopyMotive(int m)
        {
            for (int i = 1; i < item.Count; i++)
                item[0][m].CopyTo(item[i][m]);
        }


		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TtabItemMotiveTableUI));
            this.lbMotive0 = new System.Windows.Forms.Label();
            this.lbMotive1 = new System.Windows.Forms.Label();
            this.lbMotive2 = new System.Windows.Forms.Label();
            this.lbMotive3 = new System.Windows.Forms.Label();
            this.lbMotive4 = new System.Windows.Forms.Label();
            this.lbMotive5 = new System.Windows.Forms.Label();
            this.lbMotive6 = new System.Windows.Forms.Label();
            this.lbMotive7 = new System.Windows.Forms.Label();
            this.lbMotive9 = new System.Windows.Forms.Label();
            this.lbMotive11 = new System.Windows.Forms.Label();
            this.lbMotive8 = new System.Windows.Forms.Label();
            this.lbMotive10 = new System.Windows.Forms.Label();
            this.lbMotive14 = new System.Windows.Forms.Label();
            this.lbMotive15 = new System.Windows.Forms.Label();
            this.lbMotive13 = new System.Windows.Forms.Label();
            this.lbMotive12 = new System.Windows.Forms.Label();
            this.pnAllGroups = new System.Windows.Forms.Panel();
            this.cbShowAll = new System.Windows.Forms.CheckBox();
            this.pnCopyButtons = new System.Windows.Forms.Panel();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.lbCBM0 = new System.Windows.Forms.Label();
            this.btnCpyM0 = new System.Windows.Forms.Button();
            this.btnCpyM1 = new System.Windows.Forms.Button();
            this.btnCpyM2 = new System.Windows.Forms.Button();
            this.btnCpyM3 = new System.Windows.Forms.Button();
            this.btnCpyM4 = new System.Windows.Forms.Button();
            this.btnCpyM5 = new System.Windows.Forms.Button();
            this.btnCpyM7 = new System.Windows.Forms.Button();
            this.btnCpyM6 = new System.Windows.Forms.Button();
            this.btnCpyM9 = new System.Windows.Forms.Button();
            this.btnCpyM12 = new System.Windows.Forms.Button();
            this.btnCpyM11 = new System.Windows.Forms.Button();
            this.btnCpyM10 = new System.Windows.Forms.Button();
            this.btnCpyM15 = new System.Windows.Forms.Button();
            this.btnCpyM14 = new System.Windows.Forms.Button();
            this.btnCpyM13 = new System.Windows.Forms.Button();
            this.btnCpyM8 = new System.Windows.Forms.Button();
            this.lbCBM1 = new System.Windows.Forms.Label();
            this.lbCBM2 = new System.Windows.Forms.Label();
            this.lbCBM3 = new System.Windows.Forms.Label();
            this.lbCBM4 = new System.Windows.Forms.Label();
            this.lbCBM5 = new System.Windows.Forms.Label();
            this.lbCBM6 = new System.Windows.Forms.Label();
            this.lbCBM7 = new System.Windows.Forms.Label();
            this.lbCBM15 = new System.Windows.Forms.Label();
            this.lbCBM11 = new System.Windows.Forms.Label();
            this.lbCBM14 = new System.Windows.Forms.Label();
            this.lbCBM8 = new System.Windows.Forms.Label();
            this.lbCBM9 = new System.Windows.Forms.Label();
            this.lbCBM13 = new System.Windows.Forms.Label();
            this.lbCBM10 = new System.Windows.Forms.Label();
            this.lbCBM12 = new System.Windows.Forms.Label();
            this.lbNrGroups = new System.Windows.Forms.Label();
            this.pnCopyButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // lbMotive0
            //
            resources.ApplyResources(this.lbMotive0, "lbMotive0");
            this.lbMotive0.Name = "lbMotive0";
            //
            // lbMotive1
            //
            resources.ApplyResources(this.lbMotive1, "lbMotive1");
            this.lbMotive1.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive1.Name = "lbMotive1";
            //
            // lbMotive2
            //
            resources.ApplyResources(this.lbMotive2, "lbMotive2");
            this.lbMotive2.Name = "lbMotive2";
            //
            // lbMotive3
            //
            resources.ApplyResources(this.lbMotive3, "lbMotive3");
            this.lbMotive3.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive3.Name = "lbMotive3";
            //
            // lbMotive4
            //
            resources.ApplyResources(this.lbMotive4, "lbMotive4");
            this.lbMotive4.Name = "lbMotive4";
            //
            // lbMotive5
            //
            resources.ApplyResources(this.lbMotive5, "lbMotive5");
            this.lbMotive5.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive5.Name = "lbMotive5";
            //
            // lbMotive6
            //
            resources.ApplyResources(this.lbMotive6, "lbMotive6");
            this.lbMotive6.Name = "lbMotive6";
            //
            // lbMotive7
            //
            resources.ApplyResources(this.lbMotive7, "lbMotive7");
            this.lbMotive7.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive7.Name = "lbMotive7";
            //
            // lbMotive9
            //
            resources.ApplyResources(this.lbMotive9, "lbMotive9");
            this.lbMotive9.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive9.Name = "lbMotive9";
            //
            // lbMotive11
            //
            resources.ApplyResources(this.lbMotive11, "lbMotive11");
            this.lbMotive11.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive11.Name = "lbMotive11";
            //
            // lbMotive8
            //
            resources.ApplyResources(this.lbMotive8, "lbMotive8");
            this.lbMotive8.Name = "lbMotive8";
            //
            // lbMotive10
            //
            resources.ApplyResources(this.lbMotive10, "lbMotive10");
            this.lbMotive10.Name = "lbMotive10";
            //
            // lbMotive14
            //
            resources.ApplyResources(this.lbMotive14, "lbMotive14");
            this.lbMotive14.Name = "lbMotive14";
            //
            // lbMotive15
            //
            resources.ApplyResources(this.lbMotive15, "lbMotive15");
            this.lbMotive15.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive15.Name = "lbMotive15";
            //
            // lbMotive13
            //
            resources.ApplyResources(this.lbMotive13, "lbMotive13");
            this.lbMotive13.BackColor = System.Drawing.SystemColors.Control;
            this.lbMotive13.Name = "lbMotive13";
            //
            // lbMotive12
            //
            resources.ApplyResources(this.lbMotive12, "lbMotive12");
            this.lbMotive12.Name = "lbMotive12";
            //
            // pnAllGroups
            //
            resources.ApplyResources(this.pnAllGroups, "pnAllGroups");
            this.pnAllGroups.Name = "pnAllGroups";
            //
            // cbShowAll
            //
            resources.ApplyResources(this.cbShowAll, "cbShowAll");
            this.cbShowAll.Name = "cbShowAll";
            this.cbShowAll.CheckedChanged += new System.EventHandler(this.cbShowAll_CheckedChanged);
            //
            // pnCopyButtons
            //
            this.pnCopyButtons.Controls.Add(this.btnCopyAll);
            this.pnCopyButtons.Controls.Add(this.lbCBM0);
            this.pnCopyButtons.Controls.Add(this.btnCpyM0);
            this.pnCopyButtons.Controls.Add(this.btnCpyM1);
            this.pnCopyButtons.Controls.Add(this.btnCpyM2);
            this.pnCopyButtons.Controls.Add(this.btnCpyM3);
            this.pnCopyButtons.Controls.Add(this.btnCpyM4);
            this.pnCopyButtons.Controls.Add(this.btnCpyM5);
            this.pnCopyButtons.Controls.Add(this.btnCpyM7);
            this.pnCopyButtons.Controls.Add(this.btnCpyM6);
            this.pnCopyButtons.Controls.Add(this.btnCpyM9);
            this.pnCopyButtons.Controls.Add(this.btnCpyM12);
            this.pnCopyButtons.Controls.Add(this.btnCpyM11);
            this.pnCopyButtons.Controls.Add(this.btnCpyM10);
            this.pnCopyButtons.Controls.Add(this.btnCpyM15);
            this.pnCopyButtons.Controls.Add(this.btnCpyM14);
            this.pnCopyButtons.Controls.Add(this.btnCpyM13);
            this.pnCopyButtons.Controls.Add(this.btnCpyM8);
            this.pnCopyButtons.Controls.Add(this.lbCBM1);
            this.pnCopyButtons.Controls.Add(this.lbCBM2);
            this.pnCopyButtons.Controls.Add(this.lbCBM3);
            this.pnCopyButtons.Controls.Add(this.lbCBM4);
            this.pnCopyButtons.Controls.Add(this.lbCBM5);
            this.pnCopyButtons.Controls.Add(this.lbCBM6);
            this.pnCopyButtons.Controls.Add(this.lbCBM7);
            this.pnCopyButtons.Controls.Add(this.lbCBM15);
            this.pnCopyButtons.Controls.Add(this.lbCBM11);
            this.pnCopyButtons.Controls.Add(this.lbCBM14);
            this.pnCopyButtons.Controls.Add(this.lbCBM8);
            this.pnCopyButtons.Controls.Add(this.lbCBM9);
            this.pnCopyButtons.Controls.Add(this.lbCBM13);
            this.pnCopyButtons.Controls.Add(this.lbCBM10);
            this.pnCopyButtons.Controls.Add(this.lbCBM12);
            resources.ApplyResources(this.pnCopyButtons, "pnCopyButtons");
            this.pnCopyButtons.Name = "pnCopyButtons";
            //
            // btnCopyAll
            //
            resources.ApplyResources(this.btnCopyAll, "btnCopyAll");
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Click += new System.EventHandler(this.copy_Click);
            //
            // lbCBM0
            //
            resources.ApplyResources(this.lbCBM0, "lbCBM0");
            this.lbCBM0.Name = "lbCBM0";
            //
            // btnCpyM0
            //
            resources.ApplyResources(this.btnCpyM0, "btnCpyM0");
            this.btnCpyM0.Name = "btnCpyM0";
            this.btnCpyM0.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM1
            //
            this.btnCpyM1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM1, "btnCpyM1");
            this.btnCpyM1.Name = "btnCpyM1";
            this.btnCpyM1.UseVisualStyleBackColor = false;
            this.btnCpyM1.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM2
            //
            resources.ApplyResources(this.btnCpyM2, "btnCpyM2");
            this.btnCpyM2.Name = "btnCpyM2";
            this.btnCpyM2.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM3
            //
            this.btnCpyM3.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM3, "btnCpyM3");
            this.btnCpyM3.Name = "btnCpyM3";
            this.btnCpyM3.UseVisualStyleBackColor = false;
            this.btnCpyM3.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM4
            //
            resources.ApplyResources(this.btnCpyM4, "btnCpyM4");
            this.btnCpyM4.Name = "btnCpyM4";
            this.btnCpyM4.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM5
            //
            this.btnCpyM5.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM5, "btnCpyM5");
            this.btnCpyM5.Name = "btnCpyM5";
            this.btnCpyM5.UseVisualStyleBackColor = false;
            this.btnCpyM5.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM7
            //
            this.btnCpyM7.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM7, "btnCpyM7");
            this.btnCpyM7.Name = "btnCpyM7";
            this.btnCpyM7.UseVisualStyleBackColor = false;
            this.btnCpyM7.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM6
            //
            resources.ApplyResources(this.btnCpyM6, "btnCpyM6");
            this.btnCpyM6.Name = "btnCpyM6";
            this.btnCpyM6.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM9
            //
            this.btnCpyM9.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM9, "btnCpyM9");
            this.btnCpyM9.Name = "btnCpyM9";
            this.btnCpyM9.UseVisualStyleBackColor = false;
            this.btnCpyM9.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM12
            //
            resources.ApplyResources(this.btnCpyM12, "btnCpyM12");
            this.btnCpyM12.Name = "btnCpyM12";
            this.btnCpyM12.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM11
            //
            this.btnCpyM11.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM11, "btnCpyM11");
            this.btnCpyM11.Name = "btnCpyM11";
            this.btnCpyM11.UseVisualStyleBackColor = false;
            this.btnCpyM11.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM10
            //
            resources.ApplyResources(this.btnCpyM10, "btnCpyM10");
            this.btnCpyM10.Name = "btnCpyM10";
            this.btnCpyM10.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM15
            //
            this.btnCpyM15.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM15, "btnCpyM15");
            this.btnCpyM15.Name = "btnCpyM15";
            this.btnCpyM15.UseVisualStyleBackColor = false;
            this.btnCpyM15.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM14
            //
            resources.ApplyResources(this.btnCpyM14, "btnCpyM14");
            this.btnCpyM14.Name = "btnCpyM14";
            this.btnCpyM14.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM13
            //
            this.btnCpyM13.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnCpyM13, "btnCpyM13");
            this.btnCpyM13.Name = "btnCpyM13";
            this.btnCpyM13.UseVisualStyleBackColor = false;
            this.btnCpyM13.Click += new System.EventHandler(this.copy_Click);
            //
            // btnCpyM8
            //
            resources.ApplyResources(this.btnCpyM8, "btnCpyM8");
            this.btnCpyM8.Name = "btnCpyM8";
            this.btnCpyM8.Click += new System.EventHandler(this.copy_Click);
            //
            // lbCBM1
            //
            resources.ApplyResources(this.lbCBM1, "lbCBM1");
            this.lbCBM1.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM1.Name = "lbCBM1";
            //
            // lbCBM2
            //
            resources.ApplyResources(this.lbCBM2, "lbCBM2");
            this.lbCBM2.Name = "lbCBM2";
            //
            // lbCBM3
            //
            resources.ApplyResources(this.lbCBM3, "lbCBM3");
            this.lbCBM3.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM3.Name = "lbCBM3";
            //
            // lbCBM4
            //
            resources.ApplyResources(this.lbCBM4, "lbCBM4");
            this.lbCBM4.Name = "lbCBM4";
            //
            // lbCBM5
            //
            resources.ApplyResources(this.lbCBM5, "lbCBM5");
            this.lbCBM5.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM5.Name = "lbCBM5";
            //
            // lbCBM6
            //
            resources.ApplyResources(this.lbCBM6, "lbCBM6");
            this.lbCBM6.Name = "lbCBM6";
            //
            // lbCBM7
            //
            resources.ApplyResources(this.lbCBM7, "lbCBM7");
            this.lbCBM7.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM7.Name = "lbCBM7";
            //
            // lbCBM15
            //
            resources.ApplyResources(this.lbCBM15, "lbCBM15");
            this.lbCBM15.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM15.Name = "lbCBM15";
            //
            // lbCBM11
            //
            resources.ApplyResources(this.lbCBM11, "lbCBM11");
            this.lbCBM11.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM11.Name = "lbCBM11";
            //
            // lbCBM14
            //
            resources.ApplyResources(this.lbCBM14, "lbCBM14");
            this.lbCBM14.Name = "lbCBM14";
            //
            // lbCBM8
            //
            resources.ApplyResources(this.lbCBM8, "lbCBM8");
            this.lbCBM8.Name = "lbCBM8";
            //
            // lbCBM9
            //
            resources.ApplyResources(this.lbCBM9, "lbCBM9");
            this.lbCBM9.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM9.Name = "lbCBM9";
            //
            // lbCBM13
            //
            resources.ApplyResources(this.lbCBM13, "lbCBM13");
            this.lbCBM13.BackColor = System.Drawing.SystemColors.Control;
            this.lbCBM13.Name = "lbCBM13";
            //
            // lbCBM10
            //
            resources.ApplyResources(this.lbCBM10, "lbCBM10");
            this.lbCBM10.Name = "lbCBM10";
            //
            // lbCBM12
            //
            resources.ApplyResources(this.lbCBM12, "lbCBM12");
            this.lbCBM12.Name = "lbCBM12";
            //
            // lbNrGroups
            //
            resources.ApplyResources(this.lbNrGroups, "lbNrGroups");
            this.lbNrGroups.Name = "lbNrGroups";
            //
            // TtabItemMotiveTableUI
            //
            this.Controls.Add(this.lbNrGroups);
            this.Controls.Add(this.pnCopyButtons);
            this.Controls.Add(this.cbShowAll);
            this.Controls.Add(this.pnAllGroups);
            this.Controls.Add(this.lbMotive0);
            this.Controls.Add(this.lbMotive1);
            this.Controls.Add(this.lbMotive2);
            this.Controls.Add(this.lbMotive3);
            this.Controls.Add(this.lbMotive4);
            this.Controls.Add(this.lbMotive5);
            this.Controls.Add(this.lbMotive6);
            this.Controls.Add(this.lbMotive7);
            this.Controls.Add(this.lbMotive9);
            this.Controls.Add(this.lbMotive11);
            this.Controls.Add(this.lbMotive8);
            this.Controls.Add(this.lbMotive10);
            this.Controls.Add(this.lbMotive14);
            this.Controls.Add(this.lbMotive15);
            this.Controls.Add(this.lbMotive13);
            this.Controls.Add(this.lbMotive12);
            this.Name = "TtabItemMotiveTableUI";
            resources.ApplyResources(this, "$this");
            this.pnCopyButtons.ResumeLayout(false);
            this.pnCopyButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void copy_Click(object sender, System.EventArgs e)
		{
			ArrayList alBtnCopy = new ArrayList(aButtons);
			int bn = alBtnCopy.IndexOf(sender);
			if (bn >= 0)
				doCopyMotive(bn);
			else
                for (int i = 0; i < aButtons.Length; i++)
					doCopyMotive(i);
        }

		private void cbShowAll_CheckedChanged(object sender, System.EventArgs e)
		{
            pnAllGroups.Visible = cbShowAll.Enabled && cbShowAll.Checked;
            pnCopyButtons.Visible = cbShowAll.Enabled && !cbShowAll.Checked;
        }
	}
}
