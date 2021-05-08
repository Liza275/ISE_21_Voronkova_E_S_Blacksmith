﻿namespace BlacksmithView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonTakeInWork = new System.Windows.Forms.Button();
            this.buttonReady = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИзделийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияПоКомпонентамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.комопнентыПоСкладамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыПоДатамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            //
            // buttonCreate
            //
            this.buttonCreate.Location = new System.Drawing.Point(757, 57);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(181, 39);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Создать заказ";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            //
            // buttonTakeInWork
            //
            this.buttonTakeInWork.Location = new System.Drawing.Point(757, 133);
            this.buttonTakeInWork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTakeInWork.Name = "buttonTakeInWork";
            this.buttonTakeInWork.Size = new System.Drawing.Size(181, 39);
            this.buttonTakeInWork.TabIndex = 1;
            this.buttonTakeInWork.Text = "Отдать на выполнение";
            this.buttonTakeInWork.UseVisualStyleBackColor = true;
            this.buttonTakeInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            //
            // buttonReady
            //
            this.buttonReady.Location = new System.Drawing.Point(757, 214);
            this.buttonReady.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(181, 39);
            this.buttonReady.TabIndex = 2;
            this.buttonReady.Text = "Заказ готов";
            this.buttonReady.UseVisualStyleBackColor = true;
            this.buttonReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            //
            // buttonPay
            //
            this.buttonPay.Location = new System.Drawing.Point(757, 292);
            this.buttonPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(181, 39);
            this.buttonPay.TabIndex = 3;
            this.buttonPay.Text = "Заказ оплачен";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            //
            // buttonRef
            //
            this.buttonRef.Location = new System.Drawing.Point(757, 363);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(181, 39);
            this.buttonRef.TabIndex = 4;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            //
            // menuStrip1
            //
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.пополнениеСкладаToolStripMenuItem,
            this.запускРаботToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(952, 30);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            //
            // справочникиToolStripMenuItem
            //
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem,
            this.складToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            //
            // компонентыToolStripMenuItem
            //
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            //
            // изделияToolStripMenuItem
            //
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.ИзделияToolStripMenuItem_Click);
            //
            // клиентыToolStripMenuItem
            //
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            //
            // исполнителиToolStripMenuItem
            //
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            //
            // складToolStripMenuItem
            //
            this.складToolStripMenuItem.Name = "складToolStripMenuItem";
            this.складToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.складToolStripMenuItem.Text = "Склад";
            this.складToolStripMenuItem.Click += new System.EventHandler(this.складToolStripMenuItem_Click);
            //
            // отчетыToolStripMenuItem
            //
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокИзделийToolStripMenuItem,
            this.изделияПоКомпонентамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокСкладовToolStripMenuItem,
            this.комопнентыПоСкладамToolStripMenuItem,
            this.заказыПоДатамToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            //
            // списокИзделийToolStripMenuItem
            //
            this.списокИзделийToolStripMenuItem.Name = "списокИзделийToolStripMenuItem";
            this.списокИзделийToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.списокИзделийToolStripMenuItem.Text = "Список изделий";
            this.списокИзделийToolStripMenuItem.Click += new System.EventHandler(this.СписокИзделийToolStripMenuItem_Click);
            //
            // изделияПоКомпонентамToolStripMenuItem
            //
            this.изделияПоКомпонентамToolStripMenuItem.Name = "изделияПоКомпонентамToolStripMenuItem";
            this.изделияПоКомпонентамToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.изделияПоКомпонентамToolStripMenuItem.Text = "Изделия по компонентам";
            this.изделияПоКомпонентамToolStripMenuItem.Click += new System.EventHandler(this.ИзделияПоКомпонентамToolStripMenuItem_Click);
            //
            // списокЗаказовToolStripMenuItem
            //
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.СписокЗаказовToolStripMenuItem_Click);
            //
            // списокСкладовToolStripMenuItem
            //
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            //
            // комопнентыПоСкладамToolStripMenuItem
            //
            this.комопнентыПоСкладамToolStripMenuItem.Name = "комопнентыПоСкладамToolStripMenuItem";
            this.комопнентыПоСкладамToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.комопнентыПоСкладамToolStripMenuItem.Text = "Компоненты по складам";
            this.комопнентыПоСкладамToolStripMenuItem.Click += new System.EventHandler(this.комопнентыПоСкладамToolStripMenuItem_Click);
            //
            // заказыПоДатамToolStripMenuItem
            //
            this.заказыПоДатамToolStripMenuItem.Name = "заказыПоДатамToolStripMenuItem";
            this.заказыПоДатамToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.заказыПоДатамToolStripMenuItem.Text = "Заказы по датам";
            this.заказыПоДатамToolStripMenuItem.Click += new System.EventHandler(this.заказыПоДатамToolStripMenuItem_Click);
            //
            // запускРаботToolStripMenuItem
            //
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            //
            // пополнениеСкладаToolStripMenuItem
            //
            this.пополнениеСкладаToolStripMenuItem.Name = "пополнениеСкладаToolStripMenuItem";
            this.пополнениеСкладаToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.пополнениеСкладаToolStripMenuItem.Text = "Пополнение склада";
            this.пополнениеСкладаToolStripMenuItem.Click += new System.EventHandler(this.пополнениеСкладаToolStripMenuItem_Click);
            //
            // dataGridView
            //
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(8, 34);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(720, 400);
            this.dataGridView.TabIndex = 6;
            //
            // клиентыToolStripMenuItem
            //
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 437);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.buttonTakeInWork);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Кузнеца";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonTakeInWork;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИзделийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияПоКомпонентамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнениеСкладаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem комопнентыПоСкладамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыПоДатамToolStripMenuItem;
    }
}
