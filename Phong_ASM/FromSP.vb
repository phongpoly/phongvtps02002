Imports System.Data.SqlClient
Public Class FromSP
    Private Sub FillSP()
        Dim Sql As String =
            <sql>
                SELECT * FROM SANPHAM_PS02002
            </sql>
        Connect(Sql, "SANPHAM_PS02002")
        bsSP.DataSource = ds.Tables("SANPHAM_PS02002")
        dgvSP.DataSource = bsSP
        bsSP.ResetBindings(False)
    End Sub
   

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        btnAdd.Enabled = True
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnClear.Enabled = True
        txtSP.Enabled = True
        txtMaLoai.Enabled = True
        txtTenSP.Enabled = True
        txtGia.Enabled = True
        txtTT.Enabled = True
        FillSP()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim Sql As String =
            <sql>
                insert into SANPHAM_PS02002(MASP, MALOAISP, TENSP, GIASP,TRANGTHAI)
                values ('{0}', '{1}', N'{2}', '{3}', N'{4}')
            </sql>

        Sql = String.Format(Sql, txtSP.Text, txtMaLoai.Text, txtTenSP.Text, txtGia.Text, txtTT.Text)

        ExecuteNonQuery(Sql)

        FillSP()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim Sql As String =
            <sql>
                UPDATE      SANPHAM_PS02002
                SET         MALOAISP ='{1}', TENSP =N'{2}', GIASP ='{3}', TRANGTHAI =N'{4}'
                WHERE        (MASP = '{0}')
            </sql>

        Sql = String.Format(Sql, txtSP.Text, txtMaLoai.Text, txtTenSP.Text, txtGia.Text, txtTT.Text)

        ExecuteNonQuery(Sql)

        FillSP()
    End Sub

    Private Sub dgvSP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSP.CellContentClick
        Try
            Dim RowView As DataRowView = bsSP.Current
            Dim Row As DataRow = RowView.Row

            txtSP.Text = Row("MASP")
            txtMaLoai.Text = Row("MALOAISP")
            txtTenSP.Text = Row("TENSP")
            txtGia.Text = Row("GIASP")
            txtTT.Text = Row("TRANGTHAI")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Sql As String =
            <sql>
                DELETE FROM SANPHAM_PS02002
                WHERE        (SANPHAM_PS02002.MASP = '{0}')
            </sql>
        Sql = String.Format(Sql, txtSP.Text)

        ExecuteNonQuery(Sql)

        FillSP()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtSP.Clear()
        txtMaLoai.Clear()
        txtGia.Clear()
        txtTT.Clear()
        txtTenSP.Clear()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Main.Show()
    End Sub
End Class