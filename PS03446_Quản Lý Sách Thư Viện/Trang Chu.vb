Public Class frmTrangChu

    Private Sub tsbVaoThuVien_Click(sender As Object, e As EventArgs) Handles tsbVaoThuVien.Click
        frmQuanLySachThuVien.MdiParent = Me
        frmQuanLySachThuVien.Show()
        frmQuanLySachThuVien.BringToFront()
    End Sub

    Private Sub btnQuanLy_Click(sender As Object, e As EventArgs) Handles tsbQuanLy.Click
        If tsbTrangThai.Text = "Đăng xuất" Then
            frmQuanLy.BringToFront()
            frmQuanLySachThuVien.Close()
            frmTimKiem.Close()
        Else
            frmDangNhap.ShowDialog()
        End If
    End Sub

    Private Sub tsbTimKiem_Click(sender As Object, e As EventArgs) Handles tsbTimKiem.Click
        frmTimKiem.MdiParent = Me
        frmTimKiem.Show()
        frmTimKiem.BringToFront()
        frmQuanLySachThuVien.Close()
        frmQuanLy.Close()
    End Sub

    Private Sub tsbThoat_Click(sender As Object, e As EventArgs) Handles tsbThoat.Click
        Me.Close()
    End Sub

    Private Sub tsbTrangThai_Click(sender As Object, e As EventArgs) Handles tsbTrangThai.Click
        tsbTrangThai.Text = ""
        frmQuanLy.Close()
    End Sub
End Class