namespace organization.report.app;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        pictureBox.AllowDrop = true;
        pictureBox.DragEnter += PictureBox_DragEnter;
        pictureBox.DragDrop += PictureBox_DragDrop;
    }

    private void PictureBox_DragEnter(object sender, DragEventArgs e)
    {
        // Permite que o PictureBox aceite os arquivos
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    private void PictureBox_DragDrop(object sender, DragEventArgs e)
    {
        // Obtém os arquivos que foram arrastados
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

        // Adiciona os arquivos ao ListBox e começa o upload
        foreach (string file in files)
        {
            listBox.Items.Add(file); // Adiciona o nome do arquivo à ListBox
            StartUpload(file); // Inicia o upload do arquivo
        }
    }

    private async void StartUpload(string filePath)
    {
        // Configura o HttpClient para enviar o arquivo
        using (var client = new HttpClient())
        {
            var content = new MultipartFormDataContent();
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.Add("Content-Type", "application/octet-stream");
            content.Add(fileContent, "file", Path.GetFileName(filePath));

            // Atualiza a ProgressBar com o progresso do upload
            var progress = new Progress<int>(percent =>
            {
                progressBar.Value = percent; // Atualiza o valor da ProgressBar
            });

            // Realiza o upload do arquivo para o servidor (modifique a URL conforme necessário)
            var response = await client.PostAsync("http://localhost:5000/upload", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Upload completo!");
            }
            else
            {
                MessageBox.Show("Falha no upload.");
            }
        }
    }

    private void InitializeComponent()
    {
        this.pictureBox = new System.Windows.Forms.PictureBox();
        this.listBox = new System.Windows.Forms.ListBox();
        this.progressBar = new System.Windows.Forms.ProgressBar();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
        this.SuspendLayout();

        // 
        // pictureBox
        // 
        this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pictureBox.Location = new System.Drawing.Point(12, 12);
        this.pictureBox.Name = "pictureBox";
        this.pictureBox.Size = new System.Drawing.Size(300, 150);
        this.pictureBox.TabIndex = 0;
        this.pictureBox.TabStop = false;
        this.pictureBox.Text = "Arraste os arquivos aqui";

        // 
        // listBox
        // 
        this.listBox.FormattingEnabled = true;
        this.listBox.ItemHeight = 16;
        this.listBox.Location = new System.Drawing.Point(12, 180);
        this.listBox.Name = "listBox";
        this.listBox.Size = new System.Drawing.Size(300, 100);
        this.listBox.TabIndex = 1;

        // 
        // progressBar
        // 
        this.progressBar.Location = new System.Drawing.Point(12, 300);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(300, 23);
        this.progressBar.TabIndex = 2;

        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(328, 335);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.listBox);
        this.Controls.Add(this.pictureBox);
        this.Name = "Form1";
        this.Text = "Upload de Arquivos";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
        this.ResumeLayout(false);
    }

    private PictureBox pictureBox;
    private ListBox listBox;
    private ProgressBar progressBar;
}