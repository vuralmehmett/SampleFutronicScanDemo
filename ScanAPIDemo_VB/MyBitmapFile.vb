Imports System.Runtime.InteropServices

Public Class BITMAPFILEHEADER
    Private bfType As UShort
    Private bfSize As UInteger
    Private bfReserved1 As UShort
    Private bfReserved2 As UShort
    Private bfOffBits As UInteger

    Public Sub New()
        bfType = 66 + 77 * &H100  ' 'B' + 'M' * 0x100
        bfReserved1 = 0
        bfReserved2 = 0
    End Sub

    Public ReadOnly Property _SizeOfBFH() As Integer
        Get
            Return (Marshal.SizeOf(bfType) + Marshal.SizeOf(bfSize) + Marshal.SizeOf(bfReserved1) _
                        + Marshal.SizeOf(bfReserved2) + Marshal.SizeOf(bfOffBits))
        End Get
    End Property

    Public WriteOnly Property _BfSize() As UInteger
        Set(ByVal value As UInteger)
            bfSize = value
        End Set
    End Property

    Public WriteOnly Property _BfOffBits() As Integer
        Set(ByVal value As Integer)
            bfOffBits = value
        End Set
    End Property

    Public Function GetByteData() As Byte()
        Dim m_Data(_SizeOfBFH - 1) As Byte
        Dim temp As Byte() = System.BitConverter.GetBytes(bfType)
        Dim offset As Integer = 0
        Array.Copy(temp, 0, m_Data, 0, temp.Length)
        offset = temp.Length
        temp = System.BitConverter.GetBytes(bfSize)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(bfReserved1)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(bfReserved2)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(bfOffBits)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        Return m_Data
    End Function
End Class

Public Class RGBQUAD
    Private rgbBlue As Byte
    Private rgbGreen As Byte
    Private rgbRed As Byte
    Private rgbReserved As Byte

    Public Sub New()
        rgbReserved = 0
    End Sub
    Public ReadOnly Property _SizeOfRgbquad() As Integer
        Get
            Return (Marshal.SizeOf(rgbBlue) + Marshal.SizeOf(rgbGreen) + Marshal.SizeOf(rgbRed) + Marshal.SizeOf(rgbReserved))
        End Get
    End Property

    Public WriteOnly Property _RGBBlue() As Byte
        Set(ByVal value As Byte)
            rgbBlue = value
        End Set
    End Property

    Public WriteOnly Property _RGBGreen() As Byte
        Set(ByVal value As Byte)
            rgbGreen = value
        End Set
    End Property

    Public WriteOnly Property _RGBRed() As Byte
        Set(ByVal value As Byte)
            rgbRed = value
        End Set
    End Property

    Public Function GetGRBTableByteData() As Byte()
        Dim m_Data(256 * _SizeOfRgbquad - 1) As Byte
        Dim nOffset As Integer = 0
        For i As Integer = 0 To 255
            m_Data(nOffset) = CByte(i)
            m_Data(nOffset + 1) = CByte(i)
            m_Data(nOffset + 2) = CByte(i)
            m_Data(nOffset + 3) = 0
            nOffset += 4
        Next i
        Return m_Data
    End Function

End Class



Public Class BITMAPINFOHEADER
    Private biSize As UInteger
    Private biWidth As Integer
    Private biHeight As Integer
    Private biPlanes As UShort
    Private biBitCount As UShort
    Private biCompression As UInteger
    Private biSizeImage As UInteger
    Private biXPelsPerMeter As Integer
    Private biYPelsPerMeter As Integer
    Private biClrUsed As UInteger
    Private biClrImportant As UInteger

    Public Sub New()
        biPlanes = 1
        biBitCount = 8
        biCompression = 0     'BI_RGB; #define BI_RGB        0L
        biSizeImage = 0
        biClrUsed = 0
        biClrImportant = 0
        biXPelsPerMeter = &H4CE6        '500DPI
        biYPelsPerMeter = &H4CE6        '500DPI
        biSize = _SizeOfBIH
    End Sub

    Public ReadOnly Property _SizeOfBIH() As Integer
        Get
            Return (Marshal.SizeOf(biSize) + Marshal.SizeOf(biWidth) + Marshal.SizeOf(biHeight) + Marshal.SizeOf(biPlanes) _
                        + Marshal.SizeOf(biBitCount) + Marshal.SizeOf(biCompression) + Marshal.SizeOf(biSizeImage) + Marshal.SizeOf(biXPelsPerMeter) _
                        + Marshal.SizeOf(biYPelsPerMeter) + Marshal.SizeOf(biClrUsed) + Marshal.SizeOf(biClrImportant))
        End Get
    End Property

    Public Property _BiSize() As UInteger
        Get
            Return biSize
        End Get
        Set(ByVal value As UInteger)
            biSize = value
        End Set
    End Property

    Public WriteOnly Property _BiWidth() As Integer
        Set(ByVal value As Integer)
            biWidth = value
        End Set
    End Property

    Public WriteOnly Property _BiHeight() As Integer
        Set(ByVal value As Integer)
            biHeight = value
        End Set
    End Property

    Public WriteOnly Property _BiXPelsPerMeter() As Integer
        Set(ByVal value As Integer)
            biXPelsPerMeter = value
        End Set
    End Property

    Public WriteOnly Property _BiYPelsPerMeter() As Integer
        Set(ByVal value As Integer)
            biYPelsPerMeter = value
        End Set
    End Property

    Public Function GetByteData() As Byte()
        Dim m_Data(_SizeOfBIH - 1) As Byte
        Dim temp As Byte() = System.BitConverter.GetBytes(biSize)
        Dim offset As Integer = 0
        Array.Copy(temp, 0, m_Data, 0, temp.Length)
        offset = temp.Length
        temp = System.BitConverter.GetBytes(biWidth)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biHeight)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biPlanes)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biBitCount)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biCompression)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biSizeImage)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biXPelsPerMeter)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biYPelsPerMeter)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biClrUsed)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        offset += temp.Length
        temp = System.BitConverter.GetBytes(biClrImportant)
        Array.Copy(temp, 0, m_Data, offset, temp.Length)
        Return m_Data
    End Function
End Class


Public Class BITMAPINFO
    Public bmiHeader As BITMAPINFOHEADER
    Public bmiColors As RGBQUAD

    Public Sub New()
        bmiHeader = New BITMAPINFOHEADER()
        bmiColors = New RGBQUAD()
    End Sub

    Public ReadOnly Property _SizeOfBI() As Integer
        Get
            Return (bmiHeader._SizeOfBIH + bmiColors._SizeOfRgbquad * 256)
        End Get
    End Property
End Class


Public Class MyBitmapFile
    Public m_fileHeaderBitmap As BITMAPFILEHEADER
    Public m_infoBitmap As BITMAPINFO
    Public m_BmpData() As Byte

    Public Sub New()
        m_fileHeaderBitmap = New BITMAPFILEHEADER()
        m_infoBitmap = New BITMAPINFO()
    End Sub

    Public Sub New(ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal pImage As Byte())
        m_fileHeaderBitmap = New BITMAPFILEHEADER()
        m_infoBitmap = New BITMAPINFO()

        Dim length As Integer = m_fileHeaderBitmap._SizeOfBFH + m_infoBitmap._SizeOfBI + nWidth * nHeight
        m_fileHeaderBitmap._BfSize = length
        m_fileHeaderBitmap._BfOffBits = m_fileHeaderBitmap._SizeOfBFH + m_infoBitmap._SizeOfBI
        m_infoBitmap.bmiHeader._BiWidth = nWidth
        m_infoBitmap.bmiHeader._BiHeight = nHeight

        ReDim m_BmpData(length - 1)
        Dim TempData() As Byte = m_fileHeaderBitmap.GetByteData()
        Array.Copy(TempData, 0, m_BmpData, 0, TempData.Length)
        Dim offset As Integer = TempData.Length
        TempData = m_infoBitmap.bmiHeader.GetByteData()
        Array.Copy(TempData, 0, m_BmpData, offset, TempData.Length)
        offset += TempData.Length
        TempData = m_infoBitmap.bmiColors.GetGRBTableByteData()
        Array.Copy(TempData, 0, m_BmpData, offset, TempData.Length)
        offset += TempData.Length
        'rotate image
        Dim pRotateImage(nWidth * nHeight - 1) As Byte
        Dim nImgOffset As Integer = 0
        For iCyc As Integer = 0 To nHeight - 1
            Array.Copy(pImage, (nHeight - iCyc - 1) * nWidth, pRotateImage, nImgOffset, nWidth)
            nImgOffset += nWidth
        Next iCyc
        Array.Copy(pRotateImage, 0, m_BmpData, offset, pRotateImage.Length)
        TempData = Nothing
        pRotateImage = Nothing
    End Sub

    Public Sub New(ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal pImage As IntPtr)
        m_fileHeaderBitmap = New BITMAPFILEHEADER()
        m_infoBitmap = New BITMAPINFO()

        Dim length As Integer = m_fileHeaderBitmap._SizeOfBFH + m_infoBitmap._SizeOfBI + nWidth * nHeight
        m_fileHeaderBitmap._BfSize = length
        m_fileHeaderBitmap._BfOffBits = m_fileHeaderBitmap._SizeOfBFH + m_infoBitmap._SizeOfBI
        m_infoBitmap.bmiHeader._BiWidth = nWidth
        m_infoBitmap.bmiHeader._BiHeight = nHeight

        ReDim m_BmpData(length - 1)
        Dim TempData() As Byte = m_fileHeaderBitmap.GetByteData()
        Array.Copy(TempData, 0, m_BmpData, 0, TempData.Length)
        Dim offset As Integer = TempData.Length
        TempData = m_infoBitmap.bmiHeader.GetByteData()
        Array.Copy(TempData, 0, m_BmpData, offset, TempData.Length)
        offset += TempData.Length
        TempData = m_infoBitmap.bmiColors.GetGRBTableByteData()
        Array.Copy(TempData, 0, m_BmpData, offset, TempData.Length)
        offset += TempData.Length
        'rotate image
        Dim pRotateImage(nWidth * nHeight - 1) As Byte
        Dim nImgOffset As Integer = 0
        Dim pPtr As IntPtr

        For iCyc As Integer = 0 To nHeight - 1
            pPtr = (pImage.ToInt32() + (nHeight - iCyc - 1) * nWidth)
            Marshal.Copy(pPtr, pRotateImage, nImgOffset, nWidth)
            nImgOffset += nWidth
        Next iCyc
        Array.Copy(pRotateImage, 0, m_BmpData, offset, pRotateImage.Length)
        TempData = Nothing
        pRotateImage = Nothing
    End Sub

    Public ReadOnly Property BitmatFileData() As Byte()
        Get
            Return m_BmpData
        End Get
    End Property
End Class
