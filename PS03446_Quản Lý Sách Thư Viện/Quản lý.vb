Imports System.Data.SqlClient
Imports System.Data
Public Class frmQuanLy
    'khai báo biến
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=QLySACH.mssql.somee.com;packet size=4096;user id=nn19944_SQLLogin_1;pwd=4hn94nioie;data source=QLySACH.mssql.somee.com;persist security info=False;initial catalog=QLySACH"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Dim ten As String
    Dim noidung As String
    Dim masach As String
    Dim hinhanh As String
    Dim trangthai As String
    Dim ngaydang As Date
    Dim tacgia As String
    Dim theloai As String

    'load frmquanly
    Private Sub frmQuanLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect.Open()
        Dim sachmoi As SqlDataAdapter = New SqlDataAdapter("select MASACH as 'Mã sách', MATL as 'Thể loại', TENSACH as 'Tên sách',  NOIDUNG as 'Nội dung',TACGIA as 'Tác giả', NGAYDANG as 'Ngày đăng' , TRANGTHAI as 'Trạng thái', FILEANH from SACH ", connect)
        dgvXemDanhSach.DataSource = db.DefaultView
        db.Clear()
        sachmoi.Fill(db)
        connect.Close()
        masach = dgvXemDanhSach.Item(0, 0).Value
        ten = dgvXemDanhSach.Item(2, 0).Value
        noidung = dgvXemDanhSach.Item(3, 0).Value
        tacgia = dgvXemDanhSach.Item(4, 0).Value
        ngaydang = dgvXemDanhSach.Item(5, 0).Value
        trangthai = dgvXemDanhSach.Item(6, 0).Value
        hinhanh = dgvXemDanhSach.Item(7, 0).Value
        theloai = dgvXemDanhSach.Item(1, 0).Value
        ptbHinhSachQL.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & dgvXemDanhSach.Item(7, 0).Value)
        ptbHinhSachQL.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    'click hiện frmthem
    Private Sub btnThemQL_Click(sender As Object, e As EventArgs) Handles btnThemQL.Click
        frmThem.Show()
    End Sub

    Private Sub btnThoatQL_Click(sender As Object, e As EventArgs) Handles btnThoatQL.Click
        Me.Close()
    End Sub

    Private Sub dgvXemDanhSach_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvXemDanhSach.CellContentClick
        Dim click As Integer = dgvXemDanhSach.CurrentCell.RowIndex
        masach = dgvXemDanhSach.Item(0, click).Value
        ten = dgvXemDanhSach.Item(2, click).Value
        noidung = dgvXemDanhSach.Item(3, click).Value
        tacgia = dgvXemDanhSach.Item(4, click).Value
        ngaydang = dgvXemDanhSach.Item(5, click).Value
        trangthai = dgvXemDanhSach.Item(6, click).Value
        hinhanh = dgvXemDanhSach.Item(7, click).Value
        theloai = dgvXemDanhSach.Item(1, click).Value
        ptbHinhSachQL.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
        ptbHinhSachQL.BackgroundImageLayout = ImageLayout.Stretch
        click = Nothing
    End Sub
    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        frmQuanLyCT.Close()
        frmQuanLyCT.Show()
        frmQuanLyCT.txtMaSachQLCT.Text = masach
        frmQuanLyCT.txtTenSachQLCT.Text = ten
        frmQuanLyCT.txtTacGia.Text = tacgia
        frmQuanLyCT.cbbTrangThai.Text = trangthai
        frmQuanLyCT.dtbNgayNhap.Text = ngaydang
        frmQuanLyCT.txtNoiDungQLCT.Text = noidung
        frmQuanLyCT.lblBiaSachQLCT.Text = hinhanh
        frmQuanLyCT.cbbTL.Text = theloai
        frmQuanLyCT.ptbHinhSachQLCT.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & hinhanh)
        frmQuanLyCT.ptbHinhSachQLCT.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim delquery As String = "delete from SACH where MASACH=@MS"
        Dim delete As SqlCommand = New SqlCommand(delquery, connect)
        Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        connect.Open()
        If resulft = Windows.Forms.DialogResult.Yes Then
            delete.Parameters.AddWithValue("@MS", masach)
            delete.ExecuteNonQuery()
            connect.Close()
            MessageBox.Show("Xóa thành công")
        End If
        'làm mới bảng
        frmQuanLy_Load(Nothing, Nothing)
    End Sub

    Private Sub btnTimKiemTK_Click(sender As Object, e As EventArgs) Handles btnTimKiemTK.Click
        Dim sql As String = "select MASACH as 'Mã sách', MATL as 'Thể loại', TENSACH as 'Tên sách',  NOIDUNG as 'Nội dung',TACGIA as 'Tác giả', NGAYDANG as 'Ngày đăng' , TRANGTHAI as 'Trạng thái', FILEANH from SACH inner join THELOAI on SACH.MATL=THELOAI.MATL where MASACH like  '%" & txtMaSachTK.Text & "%' and TENSACH like '%" & txtTenSachTK.Text & "%' and TACGIA like '%" & txtTacGia.Text & "%' "
        connect.Open()
        Dim timkiem As SqlDataAdapter = New SqlDataAdapter(sql, connect)
        dgvXemDanhSach.DataSource = db.DefaultView
        db.Clear()
        timkiem.Fill(db)
        connect.Close()
        masach = dgvXemDanhSach.Item(0, 0).Value
        ten = dgvXemDanhSach.Item(2, 0).Value
        noidung = dgvXemDanhSach.Item(3, 0).Value
        tacgia = dgvXemDanhSach.Item(4, 0).Value
        ngaydang = dgvXemDanhSach.Item(5, 0).Value
        trangthai = dgvXemDanhSach.Item(6, 0).Value
        hinhanh = dgvXemDanhSach.Item(7, 0).Value
        theloai = dgvXemDanhSach.Item(1, 0).Value
        ptbHinhSachQL.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & dgvXemDanhSach.Item(7, 0).Value)
        ptbHinhSachQL.BackgroundImageLayout = ImageLayout.Stretch
    End Sub





End Class