using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Делегат для обновления данных в TransportDataGridView.
    /// </summary>
    public delegate void UpdateTransport();

    /// <summary>
    /// Делегат поиска транспорта.
    /// </summary>
    /// <param name="transport">Объект с информацией
    /// о транспорте.</param>
    public delegate void SearchDelegate(Transport transport);

    /// <summary>
    /// Класс описывающий действия с транспортом.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Конструктор класса MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _updateTransport = UpdateTransportDataGridView;
        }

        /// <summary>
        /// Коллекция элементов с информацией о транспорте.
        /// </summary>
        private readonly List<Transport>
            _transport = new List<Transport>();

        /// <summary>
        /// Делегат обновления информации о транспорте.
        /// </summary>
        private readonly UpdateTransport
            _updateTransport = null;

        /// <summary>
        /// Объект c информацией об удаляемом объекте. 
        /// </summary>
        private readonly Transport
            _delTransport = new Transport();

        /// <summary>
        /// Поле с информацией о пути к файлу.
        /// </summary>
        private string _pathToFile;

        /// <summary>
        /// Метод обновления информации в TransportDataGridView.
        /// </summary>
        internal void UpdateTransportDataGridView()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.SuspendBinding();
            bindingSource.DataSource = _transport;
            bindingSource.ResumeBinding();
            TransportDataGridView.DataSource = bindingSource;

            TransportDataGridView.ClearSelection();
        }

        /// <summary>
        /// Событие при нажатии на кнопку загрузить.
        /// </summary>
        private void LoadToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (_pathToFile != null)
            {
                openDialog.InitialDirectory = _pathToFile;
            }
            else
            {
                openDialog.InitialDirectory =
                    Application.StartupPath;
            }
            openDialog.Filter = "TransportBase *.trb|*.trb";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _pathToFile = openDialog.FileName;
                BinaryFormatter binaryFormatter =
                    new BinaryFormatter();

                using (FileStream fileStream = new FileStream(
                    openDialog.FileName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        List<Transport> openlList =
                            (List<Transport>)binaryFormatter
                            .Deserialize(fileStream);
                        if (_transport.Count > 0)
                        {
                            _transport.Clear();
                        }
                        foreach (var transport in openlList)
                        {
                            _transport.Add(transport);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить" +
                            " файл. Возможно в файле ошибка.\n");
                    }
                }
                UpdateTransportDataGridView();
            }
            openDialog.Dispose();
        }

        /// <summary>
        /// Событие при нажатии на кнопку добавить.
        /// </summary>
        private void AddToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            AddForm addForm = new AddForm(_transport,
                _updateTransport);
            addForm.ShowDialog();
            UpdateTransportDataGridView();
            addForm.Dispose();
        }

        /// <summary>
        /// Событие при нажатии на кнопку удалить.
        /// </summary>
        private void DelToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            if (TransportDataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow transport in
                             this.TransportDataGridView
                             .SelectedRows)
                {
                    _delTransport.TransportName =
                        TransportDataGridView[0, transport.Index]
                        .Value.ToString();
                    _delTransport.FuelUsed = Convert.ToDouble
                        (TransportDataGridView[1,
                        transport.Index].Value);
                }

                foreach (var transport in _transport)
                {
                    if ((transport.TransportName
                        == _delTransport.TransportName)
                        && (transport.FuelUsed
                        == _delTransport.FuelUsed))
                    {
                        _transport.Remove(transport);
                        break;
                    }
                }
                UpdateTransportDataGridView();
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопку сохранить.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            if (_pathToFile != null)
            {
                saveDialog.InitialDirectory = _pathToFile;
            }
            else
            {
                saveDialog.InitialDirectory =
                    Application.StartupPath;
            }
            saveDialog.Filter = "TransportBase *.trb|*.trb";

            List<Transport> saveList = new List<Transport>();
            foreach (var transport in _transport)
            {
                saveList.Add(transport);
            }

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _pathToFile = saveDialog.FileName;
                BinaryFormatter binaryFormatter =
                    new BinaryFormatter();
                using (FileStream fileStream = new FileStream(
                    saveDialog.FileName, FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(fileStream,
                        saveList);
                }
            }
            saveDialog.Dispose();
        }

        /// <summary>
        /// Событие при нажатии на кнопку найти.
        /// </summary>
        private void SearctToolStripMenuItem_Click(object sender,
            EventArgs e)
        {
            SearchForm findForm = new SearchForm(new
               SearchDelegate(SearchTransport));
            findForm.ShowDialog();
            findForm.Dispose();
        }

        /// <summary>
        /// Метод поиска транспортного средства.
        /// </summary>
        /// <param name="transport">Искомое 
        /// транспортное средство.</param>
        private void SearchTransport(Transport transport)
        {
            TransportDataGridView.ClearSelection();

            for (int i = 0; i < TransportDataGridView.RowCount;
                i++)
            {
                TransportDataGridView.Rows[i].DefaultCellStyle
                    .BackColor = System.Drawing.Color.White;
            }

            if (transport.FuelUsed != null)
            {
                for (int i = 0; i < TransportDataGridView.RowCount;
                    i++)
                {
                    if (
                        (TransportDataGridView.Rows[i]
                        .Cells[0].Value.ToString() ==
                        transport.TransportName.ToString())
                        &&
                        ((double)TransportDataGridView.Rows[i]
                        .Cells[1].Value ==
                        transport.FuelUsed))
                    {
                        TransportDataGridView.Rows[i]
                            .DefaultCellStyle.BackColor =
                            System.Drawing.Color.GreenYellow;
                    }
                    else
                    {
                        TransportDataGridView.Rows[i]
                            .DefaultCellStyle.BackColor =
                            System.Drawing.Color.White;
                    }
                }
            }
            else
            {
                for (int i = 0; i < TransportDataGridView.RowCount;
                    i++)
                {

                    if ((TransportDataGridView.Rows[i].Cells[0]
                        .Value.ToString()) ==
                        transport.TransportName.ToString())
                    {
                        TransportDataGridView.Rows[i]
                            .DefaultCellStyle
                            .BackColor = System.Drawing
                            .Color.GreenYellow;
                    }
                    else
                    {
                        TransportDataGridView.Rows[i]
                            .DefaultCellStyle
                            .BackColor = System.Drawing
                            .Color.White;
                    }
                }
            }
        }
    }
}