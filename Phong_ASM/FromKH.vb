Public Class FromKH
    Private Sub FillKH()
        Dim Sql As String =
            <sql>
                SELECT * FROM KHACHHANG_PS02002
            </sql>
        Connect(Sql, "KHACHHANG_PS02002")
        bsKH.DataSource = ds.Tables("KHACHHANG_PS02002")
        dgvKH.DataSource = bsKH
        bsKH.ResetBindings(False)
    End Sub
    Private Sub FromKH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim Sql As String =
            <sql>
                insert into KHACHHANG_PS02002(MAKH, TENKH, DIACHIKH, NGAYSINHKH,DIENTHOAIKH)
                values ('{0}', N'{1}', N'{2}', N'{3}', '{4}')
            </sql>

        Sql = String.Format(Sql, txtMakh.Text, txtName.Text, txtAddress.Text, txtDate.Text, txtNumber.Text)

        ExecuteNonQuery(Sql)

        FillKH()
    End Sub

    Private Sub dgvKH_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKH.CellContentClick
        Try
            Dim RowView As DataRowView = bsKH.Current
            Dim Row As DataRow = RowView.Row

            txtMakh.Text = Row("MAKH")
            txtName.Text = Row("TENKH")
            txtAddress.Text = Row("DIACHIKH")
            txtDate.Text = Row("NGAYSINHKH")
            txtNumber.Text = Row("DIENTHOAIKH")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim Sql As String =
            <sql>
                UPDATE      KHACHHANG_PS02002
                SET         TENKH =N'{1}', DIACHIKH =N'{2}', NGAYSINHKH =N'{3}', DIENTHOAIKH ='{4}'
                WHERE        (MAKH = '{0}')
            </sql>

        Sql = String.Format(Sql, txtMakh.Text, txtName.Text, txtAddress.Text, txtDate.Text, txtNumber.Text)

        ExecuteNonQuery(Sql)

        FillKH()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtMakh.Clear()
        txtName.Clear()
        txtAddress.Clear()
        txtDate.Clear()
        txtNumber.Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Sql As String =
            <sql>
                DELETE FROM KHACHHANG_PS02002
                WHERE        (KHACHHANG_PS02002.MAKH = '{0}')
            </sql>
        Sql = String.Format(Sql, txtMakh.Text)

        ExecuteNonQuery(Sql)

        FillKH()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        btnAdd.Enabled = True
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnClear.Enabled = True
        txtMakh.Enabled = True
        txtName.Enabled = True
        txtAddress.Enabled = True
        txtDate.Enabled = True
        txtNumber.Enabled = True
        FillKH()
    End Sub
End Class