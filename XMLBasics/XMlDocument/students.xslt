<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:students="urn:students-best:Telerik"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <h1>Students Chart</h1>
      </head>
      <body>
        <table bgcolor="#E0E0E0" cellspacing="3">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Name</b>
            </td>
            <td>
              <b>Sex</b>
            </td>
            <td>
              <b>Birth day</b>
            </td>
            <td>
              <b>Phone</b>
            </td>
            <td>
              <b>Email</b>
            </td>
            <td>
              <b>Course</b>
            </td>
            <td>
              <b>Specialty</b>
            </td>
            <td>
              <b>Faculty</b>
            </td>
            <td>
              <b>Exams</b>
            </td>
            <td>
              <b>Enrollment</b>
            </td>
            <td>
              <b>Teacher endorsements</b>
            </td>
          </tr>
          <xsl:for-each select="students/student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="sex" />
              </td>
              <td>
                <xsl:value-of select="birth-date" />
              </td>
              <td>
                <xsl:value-of select="phone" />
              </td>
              <td>
                <xsl:value-of select="email" />
              </td>
              <td>
                <xsl:value-of select="course" />
              </td>
              <td>
                <xsl:value-of select="specialty" />
              </td>
              <td>
                <xsl:value-of select="faculty-number" />
              </td>
              <td>
                <table bgcolor="#E0E0E0" cellspacing="1">
                  <tr bgcolor="white">
                    <td>
                      <b>Name</b>
                    </td>
                    <td>
                      <b>Teacher</b>
                    </td>
                    <td>
                      <b>Score</b>
                    </td>
                  </tr>
                <xsl:for-each select="exam">
                  <tr bgcolor ="white">
                    <td>
                      <xsl:value-of select="name"/>
                    </td>
                    <td>
                      <xsl:value-of select="tutor"/>
                    </td>
                    <td style="text-align:right">
                      <xsl:value-of select="score"/>
                    </td>
                  </tr>
                </xsl:for-each>
                </table>
              </td>
              <td>
                <table bgcolor="#E0E0E0" cellspacing="1">
                  <tr bgcolor="white">
                    <td>
                      <b>Date</b>
                    </td>
                    <td>
                      <b>Score</b>
                    </td>
                  </tr>
                  <xsl:for-each select="enrollment">
                    <tr bgcolor="white">
                      <td>
                        <xsl:value-of select="date"/>
                      </td>
                      <td style="text-align:right">
                        <xsl:value-of select="examScore"/>
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </td>
              <td>
                <table bgcolor="#E0E0E0" cellspacing="1">
                  <xsl:for-each select="teachersEndorsements">
                    <tr bgcolor="white">
                      <td>
                        <xsl:value-of select="endorsement"/>
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
