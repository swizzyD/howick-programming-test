namespace Howick_Interview
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CW_input = new System.Windows.Forms.TextBox();
            this.vel_input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.vel_label = new System.Windows.Forms.Label();
            this.state_label = new System.Windows.Forms.Label();
            this.SW_label = new System.Windows.Forms.Label();
            this.FR_Active = new System.Windows.Forms.Button();
            this.FR_complete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control Word";
            // 
            // CW_input
            // 
            this.CW_input.Location = new System.Drawing.Point(152, 91);
            this.CW_input.MaxLength = 16;
            this.CW_input.Name = "CW_input";
            this.CW_input.Size = new System.Drawing.Size(164, 23);
            this.CW_input.TabIndex = 1;
            this.CW_input.TextChanged += new System.EventHandler(this.CW_input_TextChanged);
            // 
            // vel_input
            // 
            this.vel_input.Location = new System.Drawing.Point(152, 130);
            this.vel_input.MaxLength = 16;
            this.vel_input.Name = "vel_input";
            this.vel_input.Size = new System.Drawing.Size(164, 23);
            this.vel_input.TabIndex = 1;
            this.vel_input.TextChanged += new System.EventHandler(this.vel_input_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motor Target Velocity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Motor Actual Velocity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Status Word";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "State";
            // 
            // vel_label
            // 
            this.vel_label.AutoSize = true;
            this.vel_label.Location = new System.Drawing.Point(152, 171);
            this.vel_label.Name = "vel_label";
            this.vel_label.Size = new System.Drawing.Size(0, 15);
            this.vel_label.TabIndex = 6;
            // 
            // state_label
            // 
            this.state_label.AutoSize = true;
            this.state_label.Location = new System.Drawing.Point(152, 243);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(0, 15);
            this.state_label.TabIndex = 7;
            // 
            // SW_label
            // 
            this.SW_label.AutoSize = true;
            this.SW_label.Location = new System.Drawing.Point(152, 209);
            this.SW_label.Name = "SW_label";
            this.SW_label.Size = new System.Drawing.Size(0, 15);
            this.SW_label.TabIndex = 8;
            // 
            // FR_Active
            // 
            this.FR_Active.Location = new System.Drawing.Point(58, 287);
            this.FR_Active.Name = "FR_Active";
            this.FR_Active.Size = new System.Drawing.Size(123, 23);
            this.FR_Active.TabIndex = 9;
            this.FR_Active.Text = "Fault Reaction";
            this.FR_Active.UseVisualStyleBackColor = true;
            this.FR_Active.Click += new System.EventHandler(this.FR_Active_Click);
            // 
            // FR_complete
            // 
            this.FR_complete.Location = new System.Drawing.Point(219, 287);
            this.FR_complete.Name = "FR_complete";
            this.FR_complete.Size = new System.Drawing.Size(163, 23);
            this.FR_complete.TabIndex = 10;
            this.FR_complete.Text = "Fault Reaction Complete";
            this.FR_complete.UseVisualStyleBackColor = true;
            this.FR_complete.Click += new System.EventHandler(this.FR_complete_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(660, 340);
            this.Controls.Add(this.FR_complete);
            this.Controls.Add(this.FR_Active);
            this.Controls.Add(this.SW_label);
            this.Controls.Add(this.state_label);
            this.Controls.Add(this.vel_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CW_input);
            this.Controls.Add(this.vel_input);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CW_input;
        private System.Windows.Forms.TextBox vel_input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label vel_label;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.Label SW_label;
        private System.Windows.Forms.Button FR_Active;
        private System.Windows.Forms.Button FR_complete;
    }
}

