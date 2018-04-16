Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
'using System.Windows.Controls;
'using System.Windows.Data;
'using System.Windows.Documents;
'using System.Windows.Input;
'using System.Windows.Media;
'using System.Windows.Media.Imaging;
'using System.Windows.Navigation;
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports System.Windows.Interactivity
Imports GridColumnDefinition = DevExpress.Xpf.Grid.ColumnDefinition
Imports GridRowDefinition = DevExpress.Xpf.Grid.RowDefinition

Namespace GridBandedView.Tutorial
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			DataContext = New DataList()
			InitializeComponent()
			grid.View = CreateView()
			InitializeColumns()
		End Sub
		Private Sub InitializeColumns()
			Dim bandIndex As Integer = 0
			Dim bandCol = New GridColumn With {.FieldName = "MyBand"}
			BandedViewBehavior.SetRow(bandCol, 0)
			BandedViewBehavior.SetColumn(bandCol, bandIndex * 2)
			BandedViewBehavior.SetColumnSpan(bandCol, 2)
			BandedViewBehavior.SetIsBand(bandCol, True)
			grid.Columns.Add(bandCol)

			Dim col1 = New GridColumn With {.FieldName = "First"}
			BandedViewBehavior.SetRow(col1, 1)
			BandedViewBehavior.SetColumn(col1, bandIndex * 2)
			grid.Columns.Add(col1)

			Dim col2 = New GridColumn With {.FieldName = "Second"}
			BandedViewBehavior.SetRow(col2, 1)
			BandedViewBehavior.SetColumn(col2, bandIndex * 2 + 1)
			grid.Columns.Add(col2)
		End Sub
		Private Function CreateView() As TableView
			Dim tableView As New TableView()
			System.Windows.Interactivity.Interaction.GetBehaviors(tableView).Add(CreateBehavior())
			Return tableView
		End Function
		Private Function CreateBehavior() As BandedViewBehavior
			Dim behavior As New BandedViewBehavior()
			behavior.ColumnDefinitions.Add(CreateGridColumnDefinition())
			behavior.ColumnDefinitions.Add(CreateGridColumnDefinition())
			behavior.RowDefinitions.Add(CreateGridRowDefinition())
			behavior.RowDefinitions.Add(CreateGridRowDefinition())
			behavior.TemplatesContainer = New TemplatesContainer()
			Return behavior
		End Function
		Private Function CreateGridColumnDefinition() As GridColumnDefinition
			Dim cd As New DevExpress.Xpf.Grid.ColumnDefinition()
			cd.Width = New GridLength(1R, GridUnitType.Auto)
			Return cd
		End Function
		Private Function CreateGridRowDefinition() As GridRowDefinition
			Dim r As New GridRowDefinition()
			r.Height = New GridLength(1R, GridUnitType.Auto)
			Return r
		End Function


		Private Sub CrearColumn(ByVal c As GridColumn)
			BandedViewBehavior.SetRow(c, 0)
			BandedViewBehavior.SetColumn(c, 0)
			BandedViewBehavior.SetRowSpan(c, 0)
			BandedViewBehavior.SetColumnSpan(c, 0)
			BandedViewBehavior.SetIsBand(c, False)
			c.Visible = False
		End Sub

	End Class
	Public Class DataList
		Inherits List(Of Data)
		Public Sub New()
			For i As Integer = 0 To 19
				Dim d As New Data() With {.First = "First #" & i.ToString(), .Second = "Second #" & i.ToString()}
				Add(d)
			Next i
		End Sub
	End Class

	Public Class Data
		Private privateFirst As String
		Public Property First() As String
			Get
				Return privateFirst
			End Get
			Set(ByVal value As String)
				privateFirst = value
			End Set
		End Property
		Private privateSecond As String
		Public Property Second() As String
			Get
				Return privateSecond
			End Get
			Set(ByVal value As String)
				privateSecond = value
			End Set
		End Property
	End Class
End Namespace
