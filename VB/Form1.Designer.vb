Namespace SchedulerSortResources
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.dataModel1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.dataModel1 = New SchedulerSortResources.DataModel()
            Me.comboBox1 = New System.Windows.Forms.ComboBox()
            Me.label1 = New System.Windows.Forms.Label()
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dataModel1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dataModel1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.schedulerControl1.Location = New System.Drawing.Point(19, 52)
            Me.schedulerControl1.Margin = New System.Windows.Forms.Padding(4)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(1079, 441)
            Me.schedulerControl1.Start = New Date(2008, 9, 4, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 1
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.Resources.DataMember = "Resources"
            Me.schedulerStorage1.Resources.DataSource = Me.dataModel1BindingSource
            Me.schedulerStorage1.Resources.Mappings.Caption = "Caption"
            Me.schedulerStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerStorage1.Resources.Mappings.Id = "ID"
            ' 
            ' dataModel1BindingSource
            ' 
            Me.dataModel1BindingSource.DataSource = Me.dataModel1
            Me.dataModel1BindingSource.Position = 0
            ' 
            ' dataModel1
            ' 
            Me.dataModel1.DataSetName = "DataModel"
            Me.dataModel1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' comboBox1
            ' 
            Me.comboBox1.FormattingEnabled = True
            Me.comboBox1.Items.AddRange(New Object() { "None", "A-Z order", "Z-A order", "N of appointments"})
            Me.comboBox1.Location = New System.Drawing.Point(76, 13)
            Me.comboBox1.Margin = New System.Windows.Forms.Padding(4)
            Me.comboBox1.Name = "comboBox1"
            Me.comboBox1.Size = New System.Drawing.Size(160, 24)
            Me.comboBox1.TabIndex = 7
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(16, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(53, 17)
            Me.label1.TabIndex = 8
            Me.label1.Text = "Sorting"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1111, 508)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.comboBox1)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dataModel1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dataModel1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private WithEvents schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
        Private dataModel1BindingSource As System.Windows.Forms.BindingSource
        Private dataModel1 As DataModel
        Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
        Private label1 As System.Windows.Forms.Label
    End Class
End Namespace