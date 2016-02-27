Imports System.Data.SqlClient
Imports System.Data
Public Class frmQuanLySachThuVien
    'khai báo biến
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=QLySACH.mssql.somee.com;packet size=4096;user id=nn19944_SQLLogin_1;pwd=4hn94nioie;data source=QLySACH.mssql.somee.com;persist security info=False;initial catalog=QLySACH"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Dim ten As String
    Dim noidung As String
    Dim masach As String
    Dim hinhanh As String
    'load form
    Private Sub frmQuanLySachThuVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        masach = dgvXemDanhSach.Item(0, 0).Value
        ten = dgvXemDanhSach.Item(2, 0).Value
        noidung = dgvXemDanhSach.Item(3, 0).Value
        hinhanh = dgvXemDanhSach.Item(7, 0).Value
        ptbHinhSach.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
        ptbHinhSach.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    Private Sub cbbDanhSach_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbDanhSach.SelectedIndexChanged
        If cbbDanhSach.Text = "Tất cả" Then
            connect.Open()
            Dim danhsach As SqlDataAdapter = New SqlDataAdapter("select MASACH as 'Mã sách', THELOAI.TENTL as 'Thể loại', TENSACH as 'Tên sách',  NOIDUNG as 'Nội dung',TACGIA as 'Tác giả', NGAYDANG as 'Ngày đăng' , TRANGTHAI as 'Trạng thái', FILEANH from SACH inner join THELOAI on SACH.MATL=THELOAI.MATL", connect)
            dgvXemDanhSach.DataSource = db.DefaultView
            db.Clear()
            danhsach.Fill(db)
            connect.Close()
        ElseIf cbbDanhSach.Text = "Sách mới" Then
            connect.Open()
            Dim sachmoi As SqlDataAdapter = New SqlDataAdapter("select MASACH as 'Mã sách', THELOAI.TENTL as 'Thể loại', TENSACH as 'Tên sách',  NOIDUNG as 'Nội dung',TACGIA as 'Tác giả', NGAYDANG as 'Ngày đăng' , TRANGTHAI as 'Trạng thái', FILEANH from SACH inner join THELOAI on SACH.MATL=THELOAI.MATL order by NGAYDANG ", connect)
            dgvXemDanhSach.DataSource = db.DefaultView
            db.Clear()
            sachmoi.Fill(db)
            connect.Close()
        End If
    End Sub
    Private Sub dgvXemDanhSach_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvXemDanhSach.CellContentClick
        Dim click As Integer = dgvXemDanhSach.CurrentCell.RowIndex
        masach = dgvXemDanhSach.Item(0, click).Value
        ten = dgvXemDanhSach.Item(2, click).Value
        noidung = dgvXemDanhSach.Item(3, click).Value
        hinhanh = dgvXemDanhSach.Item(7, click).Value
        ptbHinhSach.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
        ptbHinhSach.BackgroundImageLayout = ImageLayout.Stretch
        click = Nothing
    End Sub
    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        Try
            frmChiTiet.Close()
            frmChiTiet.Show()
            frmChiTiet.lblTenSachND.Text = ten
            frmChiTiet.lblMaSachND.Text = masach
            frmChiTiet.lblNoiDungND.Text = noidung
            frmChiTiet.ptbHinhSachND.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
            frmChiTiet.ptbHinhSachND.BackgroundImageLayout = ImageLayout.Stretch
        Catch ex As Exception
            MessageBox.Show("Vui lòng chọn sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTimKiemTK_Click(sender As Object, e As EventArgs) Handles btnTimKiemTK.Click
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
        ptbHinhSach.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
        ptbHinhSach.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
End Class
