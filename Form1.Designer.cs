
namespace обработка_изображений_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.райлиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.убратьШумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднееГеометрическоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSNRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.серыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.билатариальныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.шумToolStripMenuItem,
            this.убратьШумToolStripMenuItem,
            this.sSIMToolStripMenuItem,
            this.pSNRToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьФайлToolStripMenuItem,
            this.сохранитьФайлToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьФайлToolStripMenuItem
            // 
            this.загрузитьФайлToolStripMenuItem.Name = "загрузитьФайлToolStripMenuItem";
            this.загрузитьФайлToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.загрузитьФайлToolStripMenuItem.Text = "Загрузить файл";
            this.загрузитьФайлToolStripMenuItem.Click += new System.EventHandler(this.загрузитьФайлToolStripMenuItem_Click);
            // 
            // сохранитьФайлToolStripMenuItem
            // 
            this.сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
            this.сохранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.сохранитьФайлToolStripMenuItem.Text = "Сохранить как..";
            this.сохранитьФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьФайлToolStripMenuItem_Click);
            // 
            // шумToolStripMenuItem
            // 
            this.шумToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.райлиToolStripMenuItem});
            this.шумToolStripMenuItem.Name = "шумToolStripMenuItem";
            this.шумToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.шумToolStripMenuItem.Text = "Шум";
            // 
            // райлиToolStripMenuItem
            // 
            this.райлиToolStripMenuItem.Name = "райлиToolStripMenuItem";
            this.райлиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.райлиToolStripMenuItem.Text = "Райли";
            this.райлиToolStripMenuItem.Click += new System.EventHandler(this.райлиToolStripMenuItem_Click);
            // 
            // убратьШумToolStripMenuItem
            // 
            this.убратьШумToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.среднееГеометрическоеToolStripMenuItem,
            this.бкToolStripMenuItem,
            this.билатариальныйToolStripMenuItem});
            this.убратьШумToolStripMenuItem.Name = "убратьШумToolStripMenuItem";
            this.убратьШумToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.убратьШумToolStripMenuItem.Text = "Убрать шум";
            // 
            // среднееГеометрическоеToolStripMenuItem
            // 
            this.среднееГеометрическоеToolStripMenuItem.Name = "среднееГеометрическоеToolStripMenuItem";
            this.среднееГеометрическоеToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.среднееГеометрическоеToolStripMenuItem.Text = "Среднее геометрическое";
            this.среднееГеометрическоеToolStripMenuItem.Click += new System.EventHandler(this.среднееГеометрическоеToolStripMenuItem_Click);
            // 
            // бкToolStripMenuItem
            // 
            this.бкToolStripMenuItem.Name = "бкToolStripMenuItem";
            this.бкToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.бкToolStripMenuItem.Text = "Белый";
            this.бкToolStripMenuItem.Click += new System.EventHandler(this.белыйToolStripMenuItem_Click);
            // 
            // sSIMToolStripMenuItem
            // 
            this.sSIMToolStripMenuItem.Name = "sSIMToolStripMenuItem";
            this.sSIMToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.sSIMToolStripMenuItem.Text = "SSIM";
            this.sSIMToolStripMenuItem.Click += new System.EventHandler(this.sSIMToolStripMenuItem_Click);
            // 
            // pSNRToolStripMenuItem
            // 
            this.pSNRToolStripMenuItem.Name = "pSNRToolStripMenuItem";
            this.pSNRToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.pSNRToolStripMenuItem.Text = "PSNR";
            this.pSNRToolStripMenuItem.Click += new System.EventHandler(this.pSNRToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.серыйToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // серыйToolStripMenuItem
            // 
            this.серыйToolStripMenuItem.Name = "серыйToolStripMenuItem";
            this.серыйToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.серыйToolStripMenuItem.Text = "Серый";
            this.серыйToolStripMenuItem.Click += new System.EventHandler(this.серыйToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(430, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(401, 352);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 352);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // билатариальныйToolStripMenuItem
            // 
            this.билатариальныйToolStripMenuItem.Name = "билатариальныйToolStripMenuItem";
            this.билатариальныйToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.билатариальныйToolStripMenuItem.Text = "Билатериальный";
            this.билатариальныйToolStripMenuItem.Click += new System.EventHandler(this.билатариальныйToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 508);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Filters";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem райлиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem убратьШумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднееГеометрическоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSIMToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem pSNRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem серыйToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem бкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem билатариальныйToolStripMenuItem;
    }
}

