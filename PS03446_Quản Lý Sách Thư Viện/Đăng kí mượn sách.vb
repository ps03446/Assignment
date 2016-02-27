Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmDangKi
    Dim chuoiketnoi As String = "workstation id=QLySACH.mssql.somee.com;packet size=4096;user id=nn19944_SQLLogin_1;pwd=4hn94nioie;data source=QLySACH.mssql.somee.com;persist security info=False;initial catalog=QLySACH"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub frmDangKi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim chuoi As String = "0123456789"
        Dim dodaichuoi As Integer = Len(chuoi)
        Dim vitrilaykitu As Integer
        Dim sokitu As Integer
        Dim kytu As String
        Randomize()
        For sokitu = 0 To 4
            vitrilaykitu = Int(dodaichuoi * Rnd() + 1)
            kytu = Mid(chuoi, vitrilaykitu, 1)
            txtMaKH.Text += kytu
        Next
        For sokitu = 0 To 4
            vitrilaykitu = Int(dodaichuoi * Rnd() + 1)
            kytu = Mid(chuoi, vitrilaykitu, 1)
            txtHD.Text += kytu
        Next
        lblHienThiMaSach.Text = frmChiTiet.lblMaSachND.Text
        lblHienThiTenSachDK.Text = frmChiTiet.lblTenSachND.Text
        dtbNgayDK.Value = Today
        dtbNgayTra.Value = dtbNgayDK.Value.AddDays(2)
    End Sub
    Private Sub btnXacNhanDK_Click(sender As Object, e As EventArgs) Handles btnXacNhanDK.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim query As String = "Insert Into KHACHHANG values (@MAKH,@TENKH,@NGAYSINH,@DIACHI,@SDT) Insert Into HOADONMUON values (@MAHD,@MAKH,@NGAYLAP) Insert Into CHITIETMUON values (@MAHD,@MASACH,@NGAYMUON,@NGAYTRA) "
        Dim query2 As String = "Insert Into HOADONMUON values (@MAHD,@MAKH,@NGAYLAP) Insert Into CHITIETMUON values (@MAHD,@MASACH,@NGAYMUON,@NGAYTRA) "
        Dim save As SqlCommand = New SqlCommand(query, conn)
        Dim save2 As SqlCommand = New SqlCommand(query2, conn)
        conn.Open()  
        If cbMaKH.Checked = True Then
            Try
                If txtMaKH.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập mã khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtMaKH.Focus()
                    If txtHD.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        save2.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
                        save2.Parameters.AddWithValue("@MAHD", txtHD.Text)
                        save2.Parameters.AddWithValue("@NGAYLAP", dtbNgayDK.Text)
                        save2.Parameters.AddWithValue("@MASACH", lblHienThiMaSach.Text)
                        save2.Parameters.AddWithValue("@NGAYMUON", dtbNgayDK.Text)
                        save2.Parameters.AddWithValue("@NGAYTRA", dtbNgayTra.Text)
                        save2.ExecuteNonQuery()
                        conn.Close() 'đóng kết nối
                        MessageBox.Show("Thêm thành công")
                        txtHD.Text = "HD"
                        txtMaKH.Text = "KH"
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                txtHD.Text = "HD"
                txtMaKH.Text = "KH"
            End Try
            Me.Close()
        Else
            Try
                txtHoTen.Focus()
                If txtHoTen.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtHoTen.Focus()
                    If txtDiaChi.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập địa chỉ", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtDiaChi.Focus()
                        If txtSoDienThoai.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập SĐT", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                            txtSoDienThoai.Focus()
                            If txtMaKH.Text = "" Then
                                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                            Else
                                txtMaKH.Focus()
                                If txtHD.Text = "" Then
                                    MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                                Else
                                    save.Parameters.AddWithValue("@MAKH", txtMaKH.Text)
                                    save.Parameters.AddWithValue("@TENKH", txtHoTen.Text)
                                    save.Parameters.AddWithValue("@NGAYSINH", dtbNgaySinh.Text)
                                    save.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text)
                                    save.Parameters.AddWithValue("@SDT", txtSoDienThoai.Text)
                                    save.Parameters.AddWithValue("@MAHD", txtHD.Text)
                                    save.Parameters.AddWithValue("@NGAYLAP", dtbNgayDK.Text)
                                    save.Parameters.AddWithValue("@MASACH", lblHienThiMaSach.Text)
                                    save.Parameters.AddWithValue("@NGAYMUON", dtbNgayDK.Text)
                                    save.Parameters.AddWithValue("@NGAYTRA", dtbNgayTra.Text)
                                    save.ExecuteNonQuery()
                                    conn.Close() 'đóng kết nối
                                    MessageBox.Show("Thêm thành công")
                                    txtHD.Text = "HD"
                                    txtMaKH.Text = "KH"
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                txtHD.Text = "HD"
                txtMaKH.Text = "KH"
            End Try
            Me.Close()
        End If
        ' End If
        'End If
    End Sub
    'xóa nhập lại
    Private Sub btnNhapLaiDK_Click(sender As Object, e As EventArgs) Handles btnNhapLaiDK.Click
        txtHoTen.Clear()
        txtSoDienThoai.Clear()
        txtDiaChi.Clear()
    End Sub

    Private Sub cbMaKH_CheckedChanged(sender As Object, e As EventArgs) Handles cbMaKH.CheckedChanged
        If cbMaKH.Checked = True Then
            txtMaKH.ReadOnly = False
        Else
            txtMaKH.ReadOnly = True
        End If
    End Sub

    Private Sub dtbNgayTra_ValueChanged(sender As Object, e As EventArgs) Handles dtbNgayTra.ValueChanged
        If dtbNgayTra.Value < dtbNgayDK.Value Or dtbNgayTra.Value = dtbNgayDK.Value Then
            MessageBox.Show("Ngày trả sách phải sau ngày mượn sách ít nhất 1 ngày", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
            dtbNgayTra.Value = dtbNgayDK.Value.AddDays(2)
        End If
    End Sub
End Class