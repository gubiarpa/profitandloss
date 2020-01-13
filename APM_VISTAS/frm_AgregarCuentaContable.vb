Imports System.IO
Imports Apm.ProfitAndLoss.Datatier.Contract.Repository
Imports Apm.ProfitAndLoss.Datatier.Domain
Imports APM_CLASS
Imports OfficeOpenXml

Public Class frm_AgregarCuentaContable

    Public Property tipoAccion As Integer
    Public Property Cuenta As String
    Public Property Año As Integer
    Public Property Mes As Integer
    Public Property TipoConcepto As String
    Public Property Concepto As String
    Public Property SubConcepto As String
    Public Property Descripcion As String

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_AgregarCuentaContable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cargar_MesAnio()
            Cargar_TipoConcepto()
            If tipoAccion = 1 Then 'AGREGAR
                Inicializa_Controles_Agregar()
            Else 'MODIFICAR
                Inicializa_Controles_Modificar()
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo cargar la aplicación." + Environment.NewLine + ex.Message, "APM Terminals - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Inicializa_Controles_Agregar()
        Try
            Aux_CargaSubConcepto()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Inicializa_Controles_Modificar()
        Try
            Dim clsCta As New ClsCuentaContable

            txt_Cuenta.Text = Cuenta
            txt_Cuenta.Enabled = False
            cbo_Año.SelectedIndex = cbo_Año.FindString(Año.ToString)
            cbo_Año.Enabled = False
            cbo_Mes.SelectedIndex = Mes - 1
            cbo_Mes.Enabled = False
            cbo_TipConcep.SelectedIndex = cbo_TipConcep.FindString(TipoConcepto)

            cbo_Concep.DataSource = clsCta.Obtiene_Conceptos(TipoConcepto)
            cbo_Concep.DisplayMember = "Concepto"
            cbo_Concep.ValueMember = "Concepto"
            cbo_Concep.SelectedIndex = cbo_Concep.FindString(Concepto)

            cbo_SubConcep.DataSource = clsCta.Obtiene_SubConceptos(TipoConcepto, Concepto)
            cbo_SubConcep.DisplayMember = "SubConcepto"
            cbo_SubConcep.ValueMember = "SubConcepto"
            'Aux_CargaSubConcepto()
            cbo_SubConcep.SelectedIndex = cbo_SubConcep.FindString(SubConcepto)

            txt_Descripcion.Text = Descripcion
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Aux_CargaSubConcepto()
        Dim dt As New DataTable
        dt.Columns.Add("SubConcepto")

        Dim dr As DataRow = dt.NewRow
        dr("SubConcepto") = ""
        dt.Rows.InsertAt(dr, 0)

        cbo_SubConcep.DataSource = dt
        cbo_SubConcep.DisplayMember = "SubConcepto"
        cbo_SubConcep.ValueMember = "SubConcepto"
    End Sub

    Private Sub Cargar_TipoConcepto()
        Try
            Dim clsCta As New ClsCuentaContable
            cbo_TipConcep.DataSource = clsCta.Obtiene_TiposConcepto()
            cbo_TipConcep.DisplayMember = "TipoConcepto"
            cbo_TipConcep.ValueMember = "TipoConcepto"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cargar_MesAnio()
        Try
            'CARGO LOS MESES
            Dim datetimeFormat = Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat
            Dim meses_aux() As String
            Dim meses(11) As String
            Dim anioAct = Date.Today.Year
            Dim mesAct = Date.Today.Month
            meses_aux = datetimeFormat.MonthNames()
            For i = 0 To 11
                meses(i) = meses_aux(i).ToUpper
            Next
            cbo_Mes.DataSource = meses
            cbo_Mes.SelectedIndex = -1

            'CARGO LOS AÑOS
            Dim cant As Integer = 15
            Dim anios(cant) As Integer
            For i = 0 To cant
                anios(i) = i + 2010
            Next
            cbo_Año.DataSource = anios : cbo_Año.SelectedIndex = -1

            'Masivo
            cboAnioMasivo.DataSource = anios : cboAnioMasivo.SelectedIndex = -1
            cboMesMasivo.DataSource = meses : cboMesMasivo.SelectedIndex = -1

            'Replicación
            Dim aniosPrev(cant) As Integer ' : aniosPrev = anios
            For i = 0 To cant
                aniosPrev(i) = i + 2010
            Next
            Dim mesesPrev(11) As String ' : mesesPrev = meses
            For i = 0 To 11
                mesesPrev(i) = datetimeFormat.MonthNames()(i).ToUpper
            Next

            cboAnioPrev.DataSource = aniosPrev : cboAnioPrev.SelectedIndex = -1
            cboMesPrev.DataSource = mesesPrev : cboMesPrev.SelectedIndex = -1

            cboAnioNow.DataSource = anios : cboAnioNow.SelectedIndex = -1
            cboMesNow.DataSource = meses : cboMesNow.SelectedIndex = -1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cbo_TipConcep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_TipConcep.SelectedIndexChanged
        Try
            Dim clsCta As New ClsCuentaContable
            Dim tipoConcepto As String

            tipoConcepto = cbo_TipConcep.SelectedValue.ToString.Trim
            cbo_Concep.DataSource = clsCta.Obtiene_Conceptos(tipoConcepto)
            cbo_Concep.DisplayMember = "Concepto"
            cbo_Concep.ValueMember = "Concepto"
            cbo_SubConcep.DataSource = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cbo_Concep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Concep.SelectedIndexChanged
        Try
            Dim clsCta As New ClsCuentaContable
            Dim tipoConcepto As String
            Dim concepto As String

            tipoConcepto = cbo_TipConcep.SelectedValue.ToString.Trim
            concepto = cbo_Concep.SelectedValue.ToString.Trim
            cbo_SubConcep.DataSource = clsCta.Obtiene_SubConceptos(tipoConcepto, concepto)
            cbo_SubConcep.DisplayMember = "SubConcepto"
            cbo_SubConcep.ValueMember = "SubConcepto"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            Dim clsCta As New ClsCuentaContable
            Dim cabecera As String
            Dim mensajeExito, mensajeExiste As String
            Dim flag As Boolean = False

            If tipoAccion = 1 Then
                cabecera = "APM Terminals - Agregar Cuenta Contable"
                mensajeExito = "Se agregó la cuenta con éxito."
            Else
                cabecera = "APM Terminals - Modificar Cuenta Contable"
                mensajeExito = "Se modificó la cuenta con éxito."
            End If
            mensajeExiste = "La cuenta ingresada ya existe para el año y mes indicados."


            If ValidaInputs() Then
                Dim l_cuenta As String = txt_Cuenta.Text.Trim
                Dim l_año As Integer = cbo_Año.SelectedValue
                Dim l_mes As Integer = Convert.ToDateTime("01-" + cbo_Mes.SelectedItem + "-2011").Month
                Dim l_tipoConcepto As String = cbo_TipConcep.SelectedValue
                Dim l_concepto As String = cbo_Concep.SelectedValue
                Dim l_subConcepto As String = cbo_SubConcep.SelectedValue
                Dim l_descripcion As String = txt_Descripcion.Text.Trim

                If tipoAccion = 1 Then 'AGREGAR
                    If (clsCta.ExisteCuentaContable(l_cuenta, l_año, l_mes) = 0) Then
                        clsCta.AgregarCuentaContable(l_cuenta, l_año, l_mes, l_tipoConcepto, l_concepto, l_subConcepto, l_descripcion)
                        flag = True
                    Else
                        MessageBox.Show(mensajeExiste, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else 'MODIFICAR
                    Dim esta As Integer = clsCta.ExisteCuentaContable(l_cuenta, l_año, l_mes)

                    'If ((esta > 0) And (l_cuenta = Cuenta)) Or (esta = 0) Then
                    '    clsCta.ModificarCuentaContable(l_cuenta, l_año, l_mes, l_tipoConcepto, l_concepto, l_subConcepto, l_descripcion)
                    '    flag = True
                    'Else
                    '    MessageBox.Show(mensajeExiste, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'End If
                    If ((esta > 0) And (l_cuenta = Cuenta) And (l_mes = Mes) And (l_año = Año)) Or (esta = 0) Then
                        clsCta.ModificarCuentaContable(l_cuenta, l_año, l_mes, l_tipoConcepto, l_concepto, l_subConcepto, l_descripcion)
                        flag = True
                    Else
                        MessageBox.Show(mensajeExiste, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
                If flag Then
                    'frm_Mantenimiento_Cuenta_Ingreso.dgv_Cuentas.DataSource = clsCta.ConsultarCuenta(0)
                    MessageBox.Show(mensajeExito, cabecera, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    frm_Mantenimiento_CuentasContables.btn_Buscar.PerformClick()
                End If
            Else
                MessageBox.Show("Ingrese todos los datos correctamente.", cabecera, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ValidaInputs() As Boolean
        Try
            Dim cta As String = txt_Cuenta.Text.Trim
            Dim tipoConcepto As String = cbo_TipConcep.SelectedValue.ToString.Trim
            Dim concepto As String = cbo_Concep.SelectedValue.ToString.Trim
            Dim subConcepto As String = cbo_SubConcep.SelectedValue.ToString.Trim
            Dim descripcion As String = txt_Descripcion.Text.Trim

            If IsNumeric(cta) And (cta.Length = 8) And (cbo_Año.SelectedIndex >= 0) And (cbo_Mes.SelectedIndex >= 0) And (tipoConcepto.Length > 0) _
               And (concepto.Length > 0) And (subConcepto.Length > 0) And (descripcion.Length > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnBuscarArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscarArchivo.Click

        Try
            Dim myFileDlog As New OpenFileDialog()

            myFileDlog.InitialDirectory = "D:\"
            myFileDlog.Filter = "All Files (*.xlsx)|*.xlsx"
            myFileDlog.ShowDialog()
            If (myFileDlog.FileName <> String.Empty) Then txtArchivo.Text = myFileDlog.FileName
            btnCargarArchivo.Enabled = Not String.IsNullOrEmpty(txtArchivo.Text)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message), "Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnCargarArchivo_Click(sender As Object, e As EventArgs) Handles btnCargarArchivo.Click

        Dim excel As New FileInfo(txtArchivo.Text)

        btnCargarArchivo.Enabled = False
        dgvCuentas.RowCount = 1
        btnCargarMasivo.Enabled = False

        Try

            Using package = New ExcelPackage(excel)

                Dim clsCta As New ClsCuentaContable, cuentaContable As New CuentaContable
                Try
                    Dim workbook = package.Workbook                 '← Workbook
                    Dim worksheet = workbook.Worksheets.First()     '← Worksheet
                    Dim rowInit As Integer = IIf(chkHaveHeader.Checked, 2, 1)
                    '↑ Si tiene cabecera, empieza desde la 2da fila; sino, desde la 1ra



                    Dim rowCount As Integer = worksheet.Dimension.End.Row
                    dgvCuentas.Visible = False

                    If (MessageBox.Show(String.Format("¿Confirma que desea visualizar {0} filas?", rowCount - 1), "P & L : Sincronización Masiva", MessageBoxButtons.YesNo) = DialogResult.Yes) Then

                        dgvCuentas.RowCount = IIf(rowCount <= 1, 1, worksheet.Dimension.End.Row - 1)
                        dgvCuentas.ColumnCount = 5

                        Dim currentRow As Integer = 0

                        Try
                            'Header
                            dgvCuentas.Columns.Item(0).HeaderText = "Account"
                            dgvCuentas.Columns.Item(1).HeaderText = "TipoConcept"
                            dgvCuentas.Columns.Item(2).HeaderText = "Concept"
                            dgvCuentas.Columns.Item(3).HeaderText = "Subconcept"
                            dgvCuentas.Columns.Item(4).HeaderText = "Description"

                            'Content
                            Do Until (worksheet.Cells(rowInit, 1).Text = String.Empty)

                                dgvCuentas.Item(0, rowInit - 2).Value = worksheet.Cells(rowInit, 1).Value
                                dgvCuentas.Item(1, rowInit - 2).Value = worksheet.Cells(rowInit, 2).Value
                                dgvCuentas.Item(2, rowInit - 2).Value = worksheet.Cells(rowInit, 3).Value
                                dgvCuentas.Item(3, rowInit - 2).Value = worksheet.Cells(rowInit, 4).Value
                                dgvCuentas.Item(4, rowInit - 2).Value = worksheet.Cells(rowInit, 5).Value

                                'Next Row
                                rowInit += 1

                            Loop

                            'Ajustes de la grilla
                            For i As Integer = 0 To dgvCuentas.Columns.Count - 1
                                dgvCuentas.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                            Next

                            btnCargarMasivo.Enabled = CargarEnabled()

                        Catch ex As Exception
                            MessageBox.Show(String.Format("Se encontró el siguiente error: {0}", ex.Message), "Error", MessageBoxButtons.OK)
                        End Try

                        dgvCuentas.Visible = True

                    End If

                Catch ex As Exception
                    MessageBox.Show(String.Format("Se encontró el siguiente error: {0}", ex.Message), "Error", MessageBoxButtons.OK)
                End Try

            End Using
        Catch ex As Exception
            MessageBox.Show(String.Format("Se encontró el siguiente error: {0}", ex.Message), "Error", MessageBoxButtons.OK)
        End Try

        btnCargarArchivo.Enabled = True

    End Sub

    Private Sub cboAnioNow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnioNow.SelectedIndexChanged, cboMesNow.SelectedIndexChanged

        Try
            If (cboMesPrev.SelectedIndex = -1 Or cboAnioPrev.SelectedIndex = -1) Then
                'Si se seleccionó un año y mes (actual)
                If (cboAnioNow.SelectedIndex > -1 And cboMesNow.SelectedIndex > -1) Then
                    If (cboMesNow.SelectedIndex = 0) Then
                        If (cboAnioNow.SelectedIndex > 0) Then
                            cboMesPrev.SelectedIndex = cboMesPrev.Items.Count - 1 'Mes: diciembre
                            cboAnioPrev.SelectedIndex = cboAnioNow.SelectedIndex - 1
                        Else
                            cboAnioPrev.SelectedIndex = -1
                            cboMesPrev.SelectedIndex = -1
                        End If
                    Else 'Feb, Mar, Abr, ..., Dic
                        cboMesPrev.SelectedIndex = cboMesNow.SelectedIndex - 1 'Mes anterior
                        cboAnioPrev.SelectedIndex = cboAnioNow.SelectedIndex 'El mismo Año
                    End If
                Else
                    cboAnioPrev.SelectedIndex = -1
                    cboMesPrev.SelectedIndex = -1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("Se encontró el siguiente error:\n{0}", ex.Message), "", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnCargarMasivo_Click(sender As Object, e As EventArgs) Handles btnCargarMasivo.Click

        Dim bdCuentaContableRepository As New BdCuentaContableRepository,
            cuentaContable As New CuentaContable,
            numCuentasSincronizadas As Integer = 0

        Try

            btnCargarArchivo.Enabled = False
            btnCargarMasivo.Enabled = False

            If (MessageBox.Show("¿Confirma que desea cargar las cuentas previsualizadas?", "P & L : Sincronización Masiva", MessageBoxButtons.YesNo) = DialogResult.Yes) Then

                If (dgvCuentas.ColumnCount = 5) Then 'Incrementa una columna para el Status, si ésta no existe
                    dgvCuentas.ColumnCount += 1 : dgvCuentas.Columns.Item(dgvCuentas.ColumnCount - 1).HeaderText = "Status"
                    pgbCargaMasiva.Minimum = 0 : pgbCargaMasiva.Value = pgbCargaMasiva.Minimum : pgbCargaMasiva.Maximum = dgvCuentas.Rows.Count
                End If

                For currentRow As Integer = 0 To dgvCuentas.Rows.Count - 1

                    Try

                        With cuentaContable
                            .Account = dgvCuentas.Item(0, currentRow).Value
                            .Year = cboAnioMasivo.SelectedValue
                            .Month = cboMesMasivo.SelectedIndex + 1
                            .TypeConcept = dgvCuentas.Item(1, currentRow).Value
                            .Concept = dgvCuentas.Item(2, currentRow).Value
                            .Subconcept = dgvCuentas.Item(3, currentRow).Value
                            .Description = dgvCuentas.Item(4, currentRow).Value
                        End With

                        If (bdCuentaContableRepository.Read(cuentaContable.Year, cuentaContable.Month, cuentaContable.Account).Count = 0) Then

                            bdCuentaContableRepository.Create(cuentaContable)

                            pgbCargaMasiva.Value += 1

                            dgvCuentas.Item(5, currentRow).Value = "Cargado"
                            dgvCuentas.Item(5, currentRow).Style.ForeColor = Color.ForestGreen

                        Else

                            dgvCuentas.Item(5, currentRow).Value = "Ya existe"
                            dgvCuentas.Item(5, currentRow).Style.ForeColor = Color.DarkOrange

                        End If

                        numCuentasSincronizadas += 1

                    Catch ex As Exception

                        dgvCuentas.Item(5, currentRow).Value = "Error"
                        dgvCuentas.Item(5, currentRow).Style.ForeColor = Color.Red

                    End Try

                Next

                MessageBox.Show(String.Format("Se cargó {0} de {1} registros.", numCuentasSincronizadas, dgvCuentas.Rows.Count), "P & L : Sincronización Masiva", MessageBoxButtons.OK)
                pgbCargaMasiva.Value = pgbCargaMasiva.Minimum

            End If

            btnCargarMasivo.Enabled = True
            btnCargarArchivo.Enabled = True

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboAnioMasivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnioMasivo.SelectedIndexChanged, cboMesMasivo.SelectedIndexChanged
        btnCargarMasivo.Enabled = CargarEnabled()
    End Sub

    Private Function CargarEnabled() As Boolean

        Dim condition As Boolean = True

        If (condition) Then condition = (dgvCuentas.RowCount > 0)
        If (condition) Then condition = (dgvCuentas.RowCount > 0)
        If (condition) Then condition = (Not String.IsNullOrEmpty(dgvCuentas.Item(0, 0).Value))
        If (condition) Then condition = (cboAnioMasivo.SelectedIndex > -1)
        If (condition) Then condition = (cboMesMasivo.SelectedIndex > -1)

        Return condition

    End Function

    Private Sub cboAnioPrev_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnioPrev.SelectedIndexChanged, cboMesPrev.SelectedIndexChanged
        btnVerPeriodoPrev.Enabled = (cboAnioPrev.SelectedIndex > -1) And (cboMesPrev.SelectedIndex > -1)
        If (dgvPeriodoPrev.RowCount > 1) Then
            dgvPeriodoPrev.RowCount = 1
            lblCantidadCuentas.Text = String.Empty
        End If
    End Sub

    Private Sub btnVerPeriodoPrev_Click(sender As Object, e As EventArgs) Handles btnVerPeriodoPrev.Click

        Dim bdCuentaContableRepository As BdCuentaContableRepository = New BdCuentaContableRepository,
            cuentaContableList As List(Of CuentaContable),
            rowInit As Integer

        btnVerPeriodoPrev.Enabled = False
        btnReplicar.Enabled = False
        cuentaContableList = bdCuentaContableRepository.Read(cboAnioPrev.SelectedValue, cboMesPrev.SelectedIndex + 1)

        dgvPeriodoPrev.Visible = False
        lblCantidadCuentas.Text = String.Format("Cuentas Contables ({0}-{1}): {2}", cboAnioPrev.SelectedValue, (cboMesPrev.SelectedIndex + 1).ToString("00"), cuentaContableList.Count)
        dgvPeriodoPrev.RowCount = 1
        dgvPeriodoPrev.RowCount = cuentaContableList.Count + 1 'Número de filas
        dgvPeriodoPrev.ColumnCount = 5
        rowInit = 0

        'Header
        dgvPeriodoPrev.Columns.Item(0).HeaderText = "Account"
        dgvPeriodoPrev.Columns.Item(1).HeaderText = "TipoConcept"
        dgvPeriodoPrev.Columns.Item(2).HeaderText = "Concept"
        dgvPeriodoPrev.Columns.Item(3).HeaderText = "Subconcept"
        dgvPeriodoPrev.Columns.Item(4).HeaderText = "Description"

        For Each cuentaContable In cuentaContableList

            With cuentaContable
                dgvPeriodoPrev.Item(0, rowInit).Value = .Account
                dgvPeriodoPrev.Item(1, rowInit).Value = .TypeConcept
                dgvPeriodoPrev.Item(2, rowInit).Value = .Concept
                dgvPeriodoPrev.Item(3, rowInit).Value = .Subconcept
                dgvPeriodoPrev.Item(4, rowInit).Value = .Description
            End With

            rowInit += 1 'Siguiente fila

        Next

        dgvPeriodoPrev.Visible = True
        btnReplicar.Enabled = True
        btnVerPeriodoPrev.Enabled = False

    End Sub

    Private Sub btnReplicar_Click(sender As Object, e As EventArgs) Handles btnReplicar.Click

        If (MessageBox.Show("¿Confirma que desea replicar las cuentas contables seleccionadas?", "P & L : Replicación de Cuentas Contables", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
            Try
                btnVerPeriodoPrev.Enabled = False
                btnReplicar.Enabled = False

                Dim bdCuentaContableRepository As BdCuentaContableRepository = New BdCuentaContableRepository
                Dim añoOrigen As Integer = cboAnioPrev.SelectedValue,
                    mesOrigen As Integer = cboMesPrev.SelectedIndex + 1,
                    añoDestino As Integer = cboAnioNow.SelectedValue,
                    mesDestino As Integer = cboMesNow.SelectedIndex + 1

                bdCuentaContableRepository.Replicate(añoOrigen, mesOrigen, añoDestino, mesDestino)
                MessageBox.Show("Se replicó correctamente las cuentas contables", "P & L : Sincronización de Cuentas Contables", MessageBoxButtons.OK)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "P & L : Error de sincronización", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            btnVerPeriodoPrev.Enabled = True
            btnReplicar.Enabled = True
        End If

    End Sub
End Class