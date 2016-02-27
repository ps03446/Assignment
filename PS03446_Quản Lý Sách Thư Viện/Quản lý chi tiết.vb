Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmQuanLyCT
    'khai báo biến
    Dim tenhinh As String
    Dim duongdan As String
    Dim chuoiketnoi As String = "workstation id=QLySACH.mssql.somee.com;packet size=4096;user id=nn19944_SQLLogin_1;pwd=4hn94nioie;data source=QLySACH.mssql.somee.com;persist security info=False;initial catalog=QLySACH"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Dim db As New DataTable
    'nút thoát form
    Private Sub btnThoatQLCT_Click(sender As Object, e As EventArgs) Handles btnThoatQLCT.Click
        Me.Close()
    End Sub
    'load form lấy dữ liệu từ frmQuanLy
    Private Sub frmQuanLyCT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtbNgayNhap.Value = Today
    End Sub
    'nút cập nhật hình ảnh
    Private Sub btnSuaHinhQLCT_Click(sender As Object, e As EventArgs) Handles btnSuaHinhQLCT.Click
        'khai báo biến dialog
        Dim hinhanh As New OpenFileDialog
        'điều kiện để lấy tên file
        If hinhanh.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            duongdan = hinhanh.FileName
            If duongdan.EndsWith(".png") Or duongdan.EndsWith(".jpg") Or duongdan.EndsWith(".gif") Then
                'kiểm tra file có đặt dúng thư mục và đặt tên đúng cú pháp không
                If Mid(duongdan, duongdan.Length - 21, 11) <> "\data\hinh\" Or Mid(duongdan, duongdan.Length - 10, 4) <> "Sach" Then
                    MessageBox.Show("Vui lòng đặt file hình vào mục Debug\data\hinh và đặt tên hình theo cú pháp Sachxxx", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ptbHinhSachQLCT.BackgroundImage = Image.FromFile(duongdan) 'gán hình vào khung chứa
                End If
            Else
                MessageBox.Show("File không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                hinhanh.FileName = Nothing
                duongdan = Nothing
            End If
            tenhinh = hinhanh.FileName.Substring(hinhanh.FileName.LastIndexOf("\") + 1) ' lấy tên hình 
            If tenhinh <> "" Then
                lblBiaSachQLCT.Text = tenhinh
            End If
        End If

    End Sub
    ' click nút Lưu để cập nhật file dữ liệu
    Private Sub btnLuuQLCT_Click(sender As Object, e As EventArgs) Handles btnLuuQLCT.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim updatequery As String = "update SACH set MASACH=@MS, MATL=@TL, TENSACH=@TENSACH, TACGIA=@TENTG, NOIDUNG=@ND, NGAYDANG=@NGAY , TRANGTHAI=@TRANGTHAI, FILEANH=@FILEANH where MASACH=@MS"
        Dim addupdate As SqlCommand = New SqlCommand(updatequery, conn)
        conn.Open()
        Try
            txtMaSachQLCT.Focus()
            If txtMaSachQLCT.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sách", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMaSachQLCT.Focus()
                If txtTacGia.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên tác giả", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTacGia.Focus()
                    If txtTenSachQLCT.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập tên sách", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtTenSachQLCT.Focus()
                        If txtNoiDungQLCT.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập nội dung", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                            addupdate.Parameters.AddWithValue("@MS", txtMaSachQLCT.Text)
                            addupdate.Parameters.AddWithValue("@TL", cbbTL.Text)
                            addupdate.Parameters.AddWithValue("@TENSACH", txtTenSachQLCT.Text)
                            addupdate.Parameters.AddWithValue("@TENTG", txtTacGia.Text)
                            addupdate.Parameters.AddWithValue("@ND", txtNoiDungQLCT.Text)
                            addupdate.Parameters.AddWithValue("@NGAY", dtbNgayNhap.Text)
                            addupdate.Parameters.AddWithValue("@TRANGTHAI", cbbTrangThai.Text)
                            addupdate.Parameters.AddWithValue("@FILEANH", lblBiaSachQLCT.Text)
                            addupdate.ExecuteNonQuery()
                            conn.Close() 'đóng kết nối
                            MessageBox.Show("Cập nhật thành công")
                    End If
                End If
            End If
        End If
        Catch ex As Exception
            MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try
        Me.Close()
        'Sau khi cập nhật xong sẽ tự làm mới lại bảng
        conn.Open()
        Dim sachmoi As SqlDataAdapter = New SqlDataAdapter("select MASACH as 'Mã sách', THELOAI.TENTL as 'Thể loại', TENSACH as 'Tên sách',  NOIDUNG as 'Nội dung',TACGIA as 'Tác giả', NGAYDANG as 'Ngày đăng' , TRANGTHAI as 'Trạng thái', FILEANH from SACH inner join THELOAI on SACH.MATL=THELOAI.MATL ", conn)
        frmQuanLy.dgvXemDanhSach.DataSource = db.DefaultView
        db.Clear()
        sachmoi.Fill(db)
        conn.Close()
        frmQuanLy.ptbHinhSachQL.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & frmQuanLy.dgvXemDanhSach.Item(7, 0).Value)
        frmQuanLy.ptbHinhSachQL.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    'khi click vào ô sủa mã sách sẽ bôi đen toàn bộ kí tự

End Class

