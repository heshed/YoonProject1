namespace YoonProject1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.PreviosButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.Checker2Button = new System.Windows.Forms.Button();
            this.Checker1Button = new System.Windows.Forms.Button();
            this.DecisionButtonNormalDR = new System.Windows.Forms.RadioButton();
            this.DecisionButtonMildNPDR = new System.Windows.Forms.RadioButton();
            this.DecisionButtonModNPDR = new System.Windows.Forms.RadioButton();
            this.DecisionButtonPDR = new System.Windows.Forms.RadioButton();
            this.DecisionButtonSevereNPDR = new System.Windows.Forms.RadioButton();
            this.groupBoxDR = new System.Windows.Forms.GroupBox();
            this.groupBoxDR.SuspendLayout();
            this.SuspendLayout();
            // 
            // PreviosButton
            // 
            this.PreviosButton.Location = new System.Drawing.Point(805, 387);
            this.PreviosButton.Name = "PreviosButton";
            this.PreviosButton.Size = new System.Drawing.Size(126, 55);
            this.PreviosButton.TabIndex = 1;
            this.PreviosButton.Text = "Previos";
            this.PreviosButton.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(949, 387);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(126, 55);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            // 
            // Checker2Button
            // 
            this.Checker2Button.Location = new System.Drawing.Point(949, 53);
            this.Checker2Button.Name = "Checker2Button";
            this.Checker2Button.Size = new System.Drawing.Size(126, 55);
            this.Checker2Button.TabIndex = 5;
            this.Checker2Button.Text = "검사자2";
            this.Checker2Button.UseVisualStyleBackColor = true;
            // 
            // Checker1Button
            // 
            this.Checker1Button.Location = new System.Drawing.Point(805, 53);
            this.Checker1Button.Name = "Checker1Button";
            this.Checker1Button.Size = new System.Drawing.Size(126, 55);
            this.Checker1Button.TabIndex = 4;
            this.Checker1Button.Text = "검사자1";
            this.Checker1Button.UseVisualStyleBackColor = true;
            // 
            // DecisionButtonNormalDR
            // 
            this.DecisionButtonNormalDR.AutoSize = true;
            this.DecisionButtonNormalDR.Location = new System.Drawing.Point(64, 15);
            this.DecisionButtonNormalDR.Name = "DecisionButtonNormalDR";
            this.DecisionButtonNormalDR.Size = new System.Drawing.Size(94, 18);
            this.DecisionButtonNormalDR.TabIndex = 6;
            this.DecisionButtonNormalDR.TabStop = true;
            this.DecisionButtonNormalDR.Text = "Normal DR";
            this.DecisionButtonNormalDR.UseVisualStyleBackColor = true;
            // 
            // DecisionButtonMildNPDR
            // 
            this.DecisionButtonMildNPDR.AutoSize = true;
            this.DecisionButtonMildNPDR.Location = new System.Drawing.Point(64, 43);
            this.DecisionButtonMildNPDR.Name = "DecisionButtonMildNPDR";
            this.DecisionButtonMildNPDR.Size = new System.Drawing.Size(95, 18);
            this.DecisionButtonMildNPDR.TabIndex = 7;
            this.DecisionButtonMildNPDR.TabStop = true;
            this.DecisionButtonMildNPDR.Text = "Mild NPDR";
            this.DecisionButtonMildNPDR.UseVisualStyleBackColor = true;
            // 
            // DecisionButtonModNPDR
            // 
            this.DecisionButtonModNPDR.AutoSize = true;
            this.DecisionButtonModNPDR.Location = new System.Drawing.Point(64, 70);
            this.DecisionButtonModNPDR.Name = "DecisionButtonModNPDR";
            this.DecisionButtonModNPDR.Size = new System.Drawing.Size(98, 18);
            this.DecisionButtonModNPDR.TabIndex = 8;
            this.DecisionButtonModNPDR.TabStop = true;
            this.DecisionButtonModNPDR.Text = "Mod NPDR";
            this.DecisionButtonModNPDR.UseVisualStyleBackColor = true;
            // 
            // DecisionButtonPDR
            // 
            this.DecisionButtonPDR.AutoSize = true;
            this.DecisionButtonPDR.Location = new System.Drawing.Point(64, 126);
            this.DecisionButtonPDR.Name = "DecisionButtonPDR";
            this.DecisionButtonPDR.Size = new System.Drawing.Size(55, 18);
            this.DecisionButtonPDR.TabIndex = 10;
            this.DecisionButtonPDR.TabStop = true;
            this.DecisionButtonPDR.Text = "PDR";
            this.DecisionButtonPDR.UseVisualStyleBackColor = true;
            // 
            // DecisionButtonSevereNPDR
            // 
            this.DecisionButtonSevereNPDR.AutoSize = true;
            this.DecisionButtonSevereNPDR.Location = new System.Drawing.Point(64, 97);
            this.DecisionButtonSevereNPDR.Name = "DecisionButtonSevereNPDR";
            this.DecisionButtonSevereNPDR.Size = new System.Drawing.Size(115, 18);
            this.DecisionButtonSevereNPDR.TabIndex = 9;
            this.DecisionButtonSevereNPDR.TabStop = true;
            this.DecisionButtonSevereNPDR.Text = "Severe NPDR";
            this.DecisionButtonSevereNPDR.UseVisualStyleBackColor = true;
            // 
            // groupBoxDR
            // 
            this.groupBoxDR.Controls.Add(this.DecisionButtonPDR);
            this.groupBoxDR.Controls.Add(this.DecisionButtonSevereNPDR);
            this.groupBoxDR.Controls.Add(this.DecisionButtonModNPDR);
            this.groupBoxDR.Controls.Add(this.DecisionButtonMildNPDR);
            this.groupBoxDR.Controls.Add(this.DecisionButtonNormalDR);
            this.groupBoxDR.Location = new System.Drawing.Point(809, 129);
            this.groupBoxDR.Name = "groupBoxDR";
            this.groupBoxDR.Size = new System.Drawing.Size(265, 182);
            this.groupBoxDR.TabIndex = 11;
            this.groupBoxDR.TabStop = false;
            this.groupBoxDR.Text = "Select";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 466);
            this.Controls.Add(this.groupBoxDR);
            this.Controls.Add(this.Checker2Button);
            this.Controls.Add(this.Checker1Button);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviosButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxDR.ResumeLayout(false);
            this.groupBoxDR.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button PreviosButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button Checker2Button;
        private System.Windows.Forms.Button Checker1Button;
        private System.Windows.Forms.RadioButton DecisionButtonNormalDR;
        private System.Windows.Forms.RadioButton DecisionButtonMildNPDR;
        private System.Windows.Forms.RadioButton DecisionButtonModNPDR;
        private System.Windows.Forms.RadioButton DecisionButtonPDR;
        private System.Windows.Forms.RadioButton DecisionButtonSevereNPDR;
        private System.Windows.Forms.GroupBox groupBoxDR;
    }
}

