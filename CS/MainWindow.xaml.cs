using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Windows.Interactivity;
using GridColumnDefinition = DevExpress.Xpf.Grid.ColumnDefinition;
using GridRowDefinition = DevExpress.Xpf.Grid.RowDefinition;

namespace GridBandedView.Tutorial {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            DataContext = new DataList();
            InitializeComponent();
            grid.View = CreateView();
            InitializeColumns();
        }
        void InitializeColumns() {
            int bandIndex = 0;
            var bandCol = new GridColumn { FieldName = "MyBand"};
            BandedViewBehavior.SetRow(bandCol, 0);
            BandedViewBehavior.SetColumn(bandCol, bandIndex * 2);
            BandedViewBehavior.SetColumnSpan(bandCol, 2);
            BandedViewBehavior.SetIsBand(bandCol, true);
            grid.Columns.Add(bandCol);

            var col1 = new GridColumn { FieldName = "First" };
            BandedViewBehavior.SetRow(col1, 1);
            BandedViewBehavior.SetColumn(col1, bandIndex * 2);
            grid.Columns.Add(col1);

            var col2 = new GridColumn { FieldName = "Second" };
            BandedViewBehavior.SetRow(col2, 1);
            BandedViewBehavior.SetColumn(col2, bandIndex * 2 + 1);
            grid.Columns.Add(col2);
        }
        TableView CreateView() {
            TableView tableView = new TableView();
            System.Windows.Interactivity.Interaction.GetBehaviors(tableView).Add(CreateBehavior());
            return tableView;
        }
        BandedViewBehavior CreateBehavior() {
            BandedViewBehavior behavior = new BandedViewBehavior();
            behavior.ColumnDefinitions.Add(CreateGridColumnDefinition());
            behavior.ColumnDefinitions.Add(CreateGridColumnDefinition());
            behavior.RowDefinitions.Add(CreateGridRowDefinition());
            behavior.RowDefinitions.Add(CreateGridRowDefinition());
            behavior.TemplatesContainer = new TemplatesContainer();
            return behavior;
        }
        GridColumnDefinition CreateGridColumnDefinition() {
            DevExpress.Xpf.Grid.ColumnDefinition cd = new DevExpress.Xpf.Grid.ColumnDefinition();
            cd.Width = new GridLength(1d, GridUnitType.Auto);
            return cd;
        }
        GridRowDefinition CreateGridRowDefinition() {
            GridRowDefinition r = new GridRowDefinition();
            r.Height = new GridLength(1d, GridUnitType.Auto);
            return r;
        }


        void CrearColumn(GridColumn c) {
            BandedViewBehavior.SetRow(c, 0);
            BandedViewBehavior.SetColumn(c, 0);
            BandedViewBehavior.SetRowSpan(c, 0);
            BandedViewBehavior.SetColumnSpan(c, 0);
            BandedViewBehavior.SetIsBand(c, false);
            c.Visible = false;
        }

    }
    public class DataList : List<Data> {
        public DataList() {
            for(int i = 0; i < 20; i++) {
                Data d = new Data() {
                    First = "First #" + i.ToString(),
                    Second = "Second #" + i.ToString(),
                };
                Add(d);
            }
        }
    }

    public class Data {
        public string First { get; set; }
        public string Second { get; set; }
    }
}
