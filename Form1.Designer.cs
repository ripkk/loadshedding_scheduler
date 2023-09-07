namespace Loadshedding_Scheduler
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
            areaLabel = new Label();
            areaComboBox = new ComboBox();
            label1 = new Label();
            statusLabel = new Label();
            label2 = new Label();
            nextLabel = new Label();
            label3 = new Label();
            actionDropdown = new ComboBox();
            countdownTimer = new Label();
            warnInterval = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // areaLabel
            // 
            areaLabel.AutoSize = true;
            areaLabel.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            areaLabel.Location = new Point(14, 14);
            areaLabel.Name = "areaLabel";
            areaLabel.Size = new Size(40, 18);
            areaLabel.TabIndex = 1;
            areaLabel.Text = "Area";
            // 
            // areaComboBox
            // 
            areaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            areaComboBox.FormattingEnabled = true;
            areaComboBox.Location = new Point(14, 35);
            areaComboBox.Name = "areaComboBox";
            areaComboBox.Size = new Size(266, 28);
            areaComboBox.TabIndex = 2;
            areaComboBox.SelectedIndexChanged += areaComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 68);
            label1.Name = "label1";
            label1.Size = new Size(49, 18);
            label1.TabIndex = 3;
            label1.Text = "Stage";
            label1.Click += label1_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(67, 66);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(18, 20);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(14, 88);
            label2.Name = "label2";
            label2.Size = new Size(41, 18);
            label2.TabIndex = 5;
            label2.Text = "Next";
            // 
            // nextLabel
            // 
            nextLabel.AutoSize = true;
            nextLabel.Location = new Point(67, 86);
            nextLabel.Name = "nextLabel";
            nextLabel.Size = new Size(18, 20);
            nextLabel.TabIndex = 6;
            nextLabel.Text = "...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(286, 14);
            label3.Name = "label3";
            label3.Size = new Size(52, 18);
            label3.TabIndex = 7;
            label3.Text = "Action";
            // 
            // actionDropdown
            // 
            actionDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            actionDropdown.FormattingEnabled = true;
            actionDropdown.Items.AddRange(new object[] { "Shutdown", "Warning" });
            actionDropdown.Location = new Point(286, 35);
            actionDropdown.Name = "actionDropdown";
            actionDropdown.Size = new Size(121, 28);
            actionDropdown.TabIndex = 8;
            actionDropdown.SelectedIndexChanged += actionDropdown_SelectedIndexChanged;
            // 
            // countdownTimer
            // 
            countdownTimer.AutoSize = true;
            countdownTimer.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            countdownTimer.Location = new Point(245, 75);
            countdownTimer.Name = "countdownTimer";
            countdownTimer.Size = new Size(30, 27);
            countdownTimer.TabIndex = 9;
            countdownTimer.Text = "...";
            // 
            // warnInterval
            // 
            warnInterval.DisplayMember = "5 minute before";
            warnInterval.DropDownStyle = ComboBoxStyle.DropDownList;
            warnInterval.FormattingEnabled = true;
            warnInterval.Items.AddRange(new object[] { "1 minute before", "5 minutes before", "10 minutes before", "15 minutes before" });
            warnInterval.Location = new Point(413, 35);
            warnInterval.Name = "warnInterval";
            warnInterval.Size = new Size(152, 28);
            warnInterval.TabIndex = 10;
            warnInterval.ValueMember = "5 minutes before";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(413, 14);
            label4.Name = "label4";
            label4.Size = new Size(92, 18);
            label4.TabIndex = 11;
            label4.Text = "Warm me in:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 4.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(499, 100);
            label5.Name = "label5";
            label5.Size = new Size(66, 11);
            label5.TabIndex = 12;
            label5.Text = "Created by Ripkk";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 120);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(warnInterval);
            Controls.Add(countdownTimer);
            Controls.Add(actionDropdown);
            Controls.Add(label3);
            Controls.Add(nextLabel);
            Controls.Add(label2);
            Controls.Add(statusLabel);
            Controls.Add(label1);
            Controls.Add(areaComboBox);
            Controls.Add(areaLabel);
            Name = "Form1";
            Text = "Loadshedding Scheduler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label areaLabel;
        private Label label1;
        private Label statusLabel;
        private ComboBox areaComboBox;
        private Label label2;
        private Label nextLabel;
        private System.Windows.Forms.Timer scheuleUpdateTimer;
        private Label label3;
        private ComboBox actionDropdown;
        private Label countdownTimer;
        private ComboBox warnInterval;
        private Label label4;
        private Label label5;
    }
}