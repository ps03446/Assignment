Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmThem
    'khai báo biến
    Dim tenhinh As String
    Dim duongdan As String
    Dim chuoiketnoi As String = "workstation id=QLySACH.mssql.somee.com;packet size=4096;user id=nn19944_SQLLogin_1;pwd=4hn94nioie;data source=QLySACH.mssql.somee.com;persist security info=False;initial catalog=QLySACH"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Dim db As New DataTable
    ' chọn ảnh
    Private Sub btnChonHinhAnhTDS_Click(sender As Object, e As EventArgs) Handles btnChonHinhAnhTDS.Click
        Dim hinhanh As New OpenFileDialog 'khai báo biến dialog
        If hinhanh.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            duongdan = hinhanh.FileName
            If duongdan.EndsWith(".png") Or duongdan.EndsWith(".jpg") Or duongdan.EndsWith(".gif") Then 'kiểm tra đuôi file
             If Mid(duongdan, duongdan.Length - 21, 11) <> "\data\hinh\" Or Mid(duongdan, duongdan.Length - 10, 4) <> "Sach" Then
                    MessageBox.Show("Vui lòng đặt file hình vào mục Debug\data\hinh và đặt tên hình theo cú pháp Sachxxx", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ptbHinhTDS.BackgroundImage = Image.FromFile(duongdan) 'gán hình vào khung chứa
                End If
            Else
                MessageBox.Show("File không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                hinhanh.FileName = Nothing
                duongdan = Nothing
            End If
            tenhinh = hinhanh.FileName.Substring(hinhanh.FileName.LastIndexOf("\") + 1)
            If tenhinh <> "" Then
                lblTenHinh.Text = tenhinh
            End If
        End If
    End Sub
    'click thêm để ghi dữ liệu ra file danhsach.txt
    Private Sub btnThemTDS_Click(sender As Object, e As EventArgs) Handles btnThemTDS.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim query As String = "Insert Into SACH values (@MS,@TL,@TENSACH,@ND,@TENTG,@NGAY,@TRANGTHAI,@FILEANH)"
        Dim save As SqlCommand = New SqlCommand(query, conn)
        conn.Open()
        Try
            txtMaTDS.Focus()
            If txtMaTDS.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sách", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMaTDS.Focus()
                If txtTenTacGia.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên tác giả", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTenTacGia.Focus()
                    If txtTenTDS.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập tên sách", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtTenTDS.Focus()
                        If txtNoiDungTDS.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập nội dung", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                            txtNoiDungTDS.Focus()
                            If cbbTL.Text = "" Then
                                MessageBox.Show("Bạn chưa nhập mã thể loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                                save.Parameters.AddWithValue("@MS", txtMaTDS.Text)
                                save.Parameters.AddWithValue("@TL", cbbTL.Text)
                                save.Parameters.AddWithValue("@TENSACH", txtTenTDS.Text)
                                save.Parameters.AddWithValue("@TENTG", txtTenTacGia.Text)
                                save.Parameters.AddWithValue("@ND", txtNoiDungTDS.Text)
                                save.Parameters.AddWithValue("@NGAY", dtpNgayTDS.Text)
                                save.Parameters.AddWithValue("@TRANGTHAI", cbbTrangThaiTDS.Text)
                                save.Parameters.AddWithValue("@FILEANH", lblTenHinh.Text)
                                save.ExecuteNonQuery()
                            conn.Close() 'đóng kết nối
                                MessageBox.Show("Thêm thành công")
                        End If
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
        Dim sachmoi As SqlDataAdapter = New SqlDataAdapter("Select * from SACH order by NGAYDANG ", conn)
        frmQuanLy.dgvXemDanhSach.DataSource = db.DefaultView
        db.Clear()
        sachmoi.Fill(db)
        conn.Close()
        frmQuanLy.ptbHinhSachQL.BackgroundImage = Image.FromFile(Application.StartupPath & "\data\hinh\" & frmQuanLy.dgvXemDanhSach.Item(7, 0).Value)
        frmQuanLy.ptbHinhSachQL.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    'nhập lại
    Private Sub btnNhapLaiTDS_Click(sender As Object, e As EventArgs) Handles btnNhapLaiTDS.Click
        txtMaTDS.Text = ""
        txtNoiDungTDS.Clear()
        txtTenTacGia.Clear()
        txtTenTDS.Clear()
    End Sub

    Private Sub frmThem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpNgayTDS.Value = Today
    End Sub
End Class