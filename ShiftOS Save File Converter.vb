Public Class ShiftOS_Save_File_Converter
    Dim loadlines(2000) As String

    'Required for encryption of save files
    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer
    Public Const sSecretKey As String = "Password"

    Private Sub btnconvert_Click(sender As Object, e As EventArgs) Handles btnconvert.Click
        loadold()
        addlines()
        convertfile()
        MessageBox.Show("Your save file is now compatible with ShiftOS 0.0.7. Press ok then open the ShiftOS application again to start playing ShiftOS 0.0.7.", "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        HijackScreen.Close()
    End Sub

    Private Sub loadold()
        File_Crypt.DecryptFile("C:/ShiftOS/Shiftum42/SKernal.sft", "C:\ShiftOS\Shiftum42\Drivers\HDD.dri", sSecretKey)
        loadlines = IO.File.ReadAllLines("C:\ShiftOS\Shiftum42\Drivers\HDD.dri")
    End Sub

    Private Sub addlines()
        ReDim Preserve loadlines(2000)
        loadlines(308) = 105
        loadlines(309) = 69
        loadlines(310) = 4
        loadlines(311) = 4
        loadlines(312) = 2
        loadlines(313) = 2
        loadlines(314) = 10
        loadlines(315) = 10
        loadlines(316) = 10
        loadlines(317) = 10
        loadlines(318) = 10
        loadlines(319) = 10
        loadlines(320) = 10
        loadlines(321) = 10
        loadlines(322) = 10
        loadlines(323) = 10
        loadlines(324) = 10
        loadlines(325) = 10
        loadlines(326) = 10
        loadlines(327) = 10
        loadlines(328) = 10
        loadlines(329) = 10
        loadlines(330) = 10
        loadlines(331) = 10
        loadlines(332) = 10
        loadlines(333) = 10
        loadlines(334) = 10
        loadlines(335) = 10
        loadlines(336) = 10
        loadlines(337) = 10
        loadlines(338) = 10
        loadlines(339) = 10
        loadlines(340) = 10
        loadlines(341) = 10
        loadlines(342) = 10
        loadlines(343) = 10
        loadlines(344) = 10
        loadlines(345) = 10
        loadlines(346) = 10
        loadlines(347) = 10
        loadlines(348) = 10
        loadlines(349) = 10
        loadlines(350) = 10
        loadlines(351) = 10
        loadlines(352) = 10
        loadlines(353) = 10
        loadlines(354) = 10
        loadlines(355) = 10
        loadlines(356) = -16777216
        loadlines(357) = -16777216
        loadlines(358) = -16777216
        loadlines(359) = -16777216
        loadlines(360) = -16777216
        loadlines(361) = -16777216
        loadlines(362) = -16777216
        loadlines(363) = -16777216
        loadlines(364) = -16777216
        loadlines(365) = -16777216
        loadlines(366) = -16777216
        loadlines(367) = -16777216
        loadlines(368) = -16777216
        loadlines(369) = -16777216
        loadlines(370) = -16777216
        loadlines(371) = -16777216
        loadlines(372) = -16777216
        loadlines(373) = -16777216
        loadlines(374) = -16777216
        loadlines(375) = -16777216
        loadlines(376) = -16777216
        loadlines(377) = -16777216
        loadlines(378) = -16777216
        loadlines(379) = -16777216
        loadlines(380) = -16777216
        loadlines(381) = -16777216
        loadlines(382) = -16777216
        loadlines(383) = -16777216
        loadlines(384) = -16777216
        loadlines(385) = -16777216
        loadlines(386) = -16777216
        loadlines(387) = -16777216
        loadlines(388) = -16777216
        loadlines(389) = -16777216
        loadlines(390) = -16777216
        loadlines(391) = -16777216
        loadlines(392) = -16777216
        loadlines(393) = -16777216
        loadlines(394) = -16777216
        loadlines(395) = -16777216
        loadlines(396) = -16777216
        loadlines(397) = -16777216
        loadlines(398) = -16777216
        loadlines(399) = -16777216
        loadlines(400) = -16777216
        loadlines(401) = -16777216
        loadlines(402) = -16777216
        loadlines(403) = -16777216
        loadlines(404) = -16777216
        loadlines(405) = -16777216
        loadlines(406) = -16777216
        loadlines(407) = -16777216
        loadlines(408) = -16777216
        loadlines(409) = -16777216
        loadlines(410) = -16777216
        loadlines(411) = -16777216
        loadlines(412) = -16777216
        loadlines(413) = -16777216
        loadlines(414) = -16777216
        loadlines(415) = -16777216
        loadlines(416) = -16777216
        loadlines(417) = -16777216
        loadlines(418) = -16777216
        loadlines(419) = -16777216
        loadlines(420) = -16777216
        loadlines(421) = -16777216
        loadlines(422) = -16777216
        loadlines(423) = -16777216
        loadlines(424) = -16777216
        loadlines(425) = -16777216
        loadlines(426) = -16777216
        loadlines(427) = -16777216
        loadlines(428) = -16777216
        loadlines(429) = -16777216
        loadlines(430) = -16777216
        loadlines(431) = -16777216
        loadlines(432) = -16777216
        loadlines(433) = -16777216
        loadlines(434) = -16777216
        loadlines(435) = -16777216
        loadlines(436) = -16777216
        loadlines(437) = -16777216
        loadlines(438) = -16777216
        loadlines(439) = -16777216
        loadlines(440) = -16777216
        loadlines(441) = -16777216
        loadlines(442) = -16777216
        loadlines(443) = -16777216
        loadlines(444) = -16777216
        loadlines(445) = -16777216
        loadlines(446) = -16777216
        loadlines(447) = -16777216
        loadlines(448) = -16777216
        loadlines(449) = -16777216
        loadlines(450) = -16777216
        loadlines(451) = -16777216
        loadlines(452) = -16777216
        loadlines(453) = -16777216
        loadlines(454) = -16777216
        loadlines(455) = -16777216
        loadlines(456) = -16777216
        loadlines(457) = -16777216
        loadlines(458) = -16777216
        loadlines(459) = -16777216
        loadlines(460) = -16777216
        loadlines(461) = -16777216
        loadlines(462) = -16777216
        loadlines(463) = -16777216
        loadlines(464) = -16777216
        loadlines(465) = -16777216
        loadlines(466) = -16777216
        loadlines(467) = -16777216
        loadlines(468) = -16777216
        loadlines(469) = -16777216
        loadlines(470) = -16777216
        loadlines(471) = -16777216
        loadlines(472) = -16777216
        loadlines(473) = -16777216
        loadlines(474) = -16777216
        loadlines(475) = -16777216
        loadlines(476) = -16777216
        loadlines(477) = -16777216
        loadlines(478) = -16777216
        loadlines(479) = -16777216
        loadlines(480) = -16777216
        loadlines(481) = -16777216
        loadlines(482) = -16777216
        loadlines(483) = -16777216
        loadlines(484) = 10
    End Sub

    Private Sub convertfile()
        IO.File.WriteAllLines("C:\ShiftOS\Shiftum42\Drivers\HDD.dri", loadlines)
        File_Crypt.EncryptFile("C:\ShiftOS\Shiftum42\Drivers\HDD.dri", "C:/ShiftOS/Shiftum42/SKernal.sft", sSecretKey)
        Dim objWriter As New System.IO.StreamWriter("C:/ShiftOS/Shiftum42/HDAccess.sft", False)
        objWriter.Write("0.0.7")
        objWriter.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
        HijackScreen.Close()
    End Sub
End Class