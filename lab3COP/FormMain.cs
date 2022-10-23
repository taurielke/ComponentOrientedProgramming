using lab3COP.Plugins;
using lab3COP.Plugin;

namespace lab3COP
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<string, IPluginsConvention> _plugins;
        private string _selectedPlugin;
        public FormMain()
        {
            InitializeComponent();
            _plugins = LoadPlugins();
        }
        private Dictionary<string, IPluginsConvention> LoadPlugins()
        {
            // TODO ��������� IPluginsConvention
            // TODO ��������� ����� ���� "�����������" �� ������ IPluginsConvention.PluginName
            // TODO ��������, ��������� ToolStripMenuItem, ����������� � ��� ��������� ������� � ��������� � menuStrip
            // TODO ��� ������ ������ ���� �������� UserControl � ��������� �������  panelControl ���� ��������� �� ��� �������
            // ������: panelControl.Controls.Clear(); panelControl.Controls.Add(ctrl);

            var dic = new Dictionary<string, IPluginsConvention>();
            var mainPlugin = new MainPluginConvention();
            dic.Add(mainPlugin.PluginName, mainPlugin);

            System.Windows.Forms.ToolStripItem[] toolStripItems = new System.Windows.Forms.ToolStripItem[2];
            ToolStripMenuItem menuItemOrders = new ToolStripMenuItem();
            menuItemOrders.Text = mainPlugin.PluginName;
            menuItemOrders.Click += MenuItemOrders_Click;
            toolStripItems[0] = menuItemOrders;

            ToolStripMenuItem menuItemUnits = new ToolStripMenuItem();
            menuItemUnits.Text = "������ ����������";
            menuItemUnits.Click += MenuItemDestinationCities_Click;
            toolStripItems[1] = menuItemUnits;

            ControlsStripMenuItem.DropDownItems.AddRange(toolStripItems);
            return dic;
        }

        private void MenuItemDestinationCities_Click(object sender, EventArgs e)
        {
            FormDestinationCity formDestCities = new();
            formDestCities.ShowDialog();
        }

        private void MenuItemOrders_Click(object sender, EventArgs e)
        {
            _selectedPlugin = "������";
            panelControl.Controls.Clear();
            panelControl.Controls.Add(_plugins[_selectedPlugin].GetControl);
            panelControl.Controls[0].Dock = DockStyle.Fill;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedPlugin) ||
           !_plugins.ContainsKey(_selectedPlugin))
            {
                return;
            }
            if (!e.Control)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.A:
                    AddNewElement();
                    break;
                case Keys.U:
                    UpdateElement();
                    break;
                case Keys.D:
                    DeleteElement();
                    break;
                case Keys.S:
                    CreateSimpleDoc();
                    break;
                case Keys.T:
                    CreateTableDoc();
                    break;
                case Keys.C:
                    CreateChartDoc();
                    break;
            }
        }
        private void AddNewElement()
        {
            var form = _plugins[_selectedPlugin].GetForm(null);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }
        private void UpdateElement()
        {
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("��� ���������� ��������", "������",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = _plugins[_selectedPlugin].GetForm(element);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }
        private void DeleteElement()
        {
            if (MessageBox.Show("������� ��������� �������", "��������",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("��� ���������� ��������", "������",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_plugins[_selectedPlugin].DeleteElement(element))
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }
        private void CreateSimpleDoc()
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK && _plugins[_selectedPlugin].CreateSimpleDocument(
                    new PluginsConventionSaveDocument()
                    {
                        FileName = dialog.FileName
                    }))
                {
                    MessageBox.Show("�������� ��������", "�������� ���������",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("������ ��� �������� ���������", "������",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CreateTableDoc()
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK && _plugins[_selectedPlugin].CreateTableDocument(new
                    PluginsConventionSaveDocument()
                {
                    FileName = dialog.FileName
                }))
                {
                    MessageBox.Show("�������� ��������", "�������� ���������",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("������ ��� �������� ���������", "������",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CreateChartDoc()
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xls" })
            {
                if (dialog.ShowDialog() == DialogResult.OK && _plugins[_selectedPlugin].CreateChartDocument(new
                    PluginsConventionSaveDocument()
                {
                    FileName = dialog.FileName
                }))
                {
                    MessageBox.Show("�������� ��������", "�������� ���������",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("������ ��� �������� ���������", "������",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e) =>
       AddNewElement();
        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e) =>
       UpdateElement();
        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e) =>
       DeleteElement();
        private void SimpleDocToolStripMenuItem_Click(object sender, EventArgs e) =>
       CreateSimpleDoc();
        private void TableDocToolStripMenuItem_Click(object sender, EventArgs e) =>
       CreateTableDoc();
        private void ChartDocToolStripMenuItem_Click(object sender, EventArgs e) =>
       CreateChartDoc();
    }
}