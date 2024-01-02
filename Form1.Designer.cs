namespace excelToAll
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
            DropList = new ListBox();
            TransformerButton = new Button();
            buttonRemove = new Button();
            buttonFindExcel = new Button();
            SuspendLayout();
            // 
            // DropList
            // 
            DropList.FormattingEnabled = true;
            DropList.ItemHeight = 15;
            DropList.Location = new Point(62, 26);
            DropList.Name = "DropList";
            DropList.Size = new Size(703, 199);
            DropList.TabIndex = 0;
            // 
            // TransformerButton
            // 
            TransformerButton.Location = new Point(541, 265);
            TransformerButton.Name = "TransformerButton";
            TransformerButton.Size = new Size(88, 23);
            TransformerButton.TabIndex = 1;
            TransformerButton.Text = "Transformar";
            TransformerButton.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(215, 265);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(75, 23);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "remover";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonFindExcel
            // 
            buttonFindExcel.Location = new Point(358, 265);
            buttonFindExcel.Name = "buttonFindExcel";
            buttonFindExcel.Size = new Size(75, 23);
            buttonFindExcel.TabIndex = 3;
            buttonFindExcel.Text = "Buscar Arquivos";
            buttonFindExcel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonFindExcel);
            Controls.Add(buttonRemove);
            Controls.Add(TransformerButton);
            Controls.Add(DropList);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox DropList;
        private Button TransformerButton;
        private Button buttonRemove;
        private Button buttonFindExcel;
    }
}
