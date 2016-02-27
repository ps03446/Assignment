Imports System.Data.SqlClient
Imports System.Data
Public Class frmTimKiem
    'khai báo biến
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=QLySACH.mssql.somee.com;packet size=4096;user id=nn19944_SQLLogin_1;pwd=4hn94nioie;data source=QLySACH.mssql.somee.com;persist security info=False;initial catalog=QLySACH"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Dim ten As String
    Dim noidung As String
    Dim masach As String
    Dim hinhanh As String


    Private Sub btnTimKiemTK_Click(sender As Object, e As EventArgs) Handles btnTimKiemTK.Click
        Try
            Dim sql As String = "select MASACH as 'Mã sách', THELOAI.TENTL as 'Thể loại', TENSACH as 'Tên sách',  NOIDUNG as 'Nội dung',TACGIA as 'Tác giả', NGAYDANG as 'Ngày đăng' , TRANGTHAI as 'Trạng thái', FILEANH from SACH inner join THELOAI on SACH.MATL=THELOAI.MATL where MASACH like  '%" & txtMaSachTK.Text & "%' and TENSACH like '%" & txtTenSachTK.Text & "%' and TACGIA like '%" & txtTacGia.Text & "%' "
            connect.Open()
            Dim timkiem As SqlDataAdapter = New SqlDataAdapter(sql, connect)
            dgvXemDanhSach.DataSource = db.DefaultView
            db.Clear()
            timkiem.Fill(db)
            connect.Close()
            masach = dgvXemDanhSach.Item(0, 0).Value
            ten = dgvXemDanhSach.Item(2, 0).Value
            noidung = dgvXemDanhSach.Item(3, 0).Value
            hinhanh = dgvXemDanhSach.Item(7, 0).Value
            ptbHinhSachTK.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
            ptbHinhSachTK.BackgroundImageLayout = ImageLayout.Stretch
        Catch ex As Exception
            MessageBox.Show("Không tìm thấy dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMaSachTK.Clear()
            txtTacGia.Clear()
            txtTenSachTK.Clear()
        End Try
    End Sub

    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        frmChiTiet.Close()
        frmChiTiet.Show()
        frmChiTiet.lblTenSachND.Text = ten
        frmChiTiet.lblMaSachND.Text = masach
        frmChiTiet.lblNoiDungND.Text = noidung
        frmChiTiet.ptbHinhSachND.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
        frmChiTiet.ptbHinhSachND.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub dgvXemDanhSach_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvXemDanhSach.CellContentClick
        Dim click As Integer = dgvXemDanhSach.CurrentCell.RowIndex
        masach = dgvXemDanhSach.Item(0, click).Value
        ten = dgvXemDanhSach.Item(2, click).Value
        noidung = dgvXemDanhSach.Item(3, click).Value
        hinhanh = dgvXemDanhSach.Item(7, click).Value
        ptbHinhSachTK.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
        ptbHinhSachTK.BackgroundImageLayout = ImageLayout.Stretch
        click = Nothing
    End Sub

    Private Sub btnThoatTK_Click(sender As Object, e As EventArgs) Handles btnThoatTK.Click
        Me.Close()
    End Sub
End Class