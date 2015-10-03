<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:catalogue="unr:catalogue-albums:artists">
  <xsl:template match="/">
    <html>
      <head>
        <h1>Catalogue albums: </h1>
      </head>
      <body>
        <table bgcolor ="#E0E0E0" cellspacing ="2">
          <tr bgcolor="white">
            <td style="text-align:center">
              <b>Name</b>
            </td>
            <td style="text-align:center">
              <b>Artist</b>
            </td>
            <td style="text-align:center">
              <b>Year</b>
            </td>
            <td style="text-align:center">
              <b>Producer</b>
            </td>
            <td style="text-align:center">
              <b>Price</b>
            </td>
            <td style="text-align:center">
              <b>Songs</b>
            </td>
          </tr>
          <xsl:for-each select="/catalogue/album">
          <tr bgcolor="white">
            <td>
              <xsl:value-of select="name"/>
            </td>
            <td>
              <xsl:value-of select="artist"/>
            </td>
            <td>
              <xsl:value-of select="year"/>
            </td>
            <td>
              <xsl:value-of select="producer"/>
            </td>
            <td>
              <xsl:value-of select="price"/>
            </td>
            <td>
              <table bgcolor="#E0E0E0" cellspacing="1">
                <tr bgcolor="white">
                  <td>
                    <b>Title</b>
                  </td>
                  <td>
                    <b>Duration</b>
                  </td>
                </tr>
              <xsl:for-each select="songs/song">
                  <tr bgcolor="white">
                    <td style="text-align:center">
                      <xsl:value-of select="title"/>
                    </td>
                    <td style="text-align:right">
                      <xsl:value-of select="duration"/>
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
