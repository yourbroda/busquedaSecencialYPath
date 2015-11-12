Imports System.Xml
Imports System.Xml.XPath
Public Class Funciones
    Public Function lecturaSecu(ruta As String) As String 'Lee un archivo xml y añade los nodos a una frase
        Dim cont As Integer = 1
        Dim elemento As String
        Dim frase As String = " "
        Dim reader As XmlTextReader = New XmlTextReader(ruta)
        Do While (reader.Read())
            frase = frase & vbCrLf

            Select Case reader.NodeType
                Case XmlNodeType.Element
                    If (reader.Name = elemento) Then
                        cont = 1
                    End If
                    If (cont = 1) Then
                        elemento = reader.Name
                    Else
                        For index As Integer = 1 To cont
                            frase = frase + ControlChars.Tab
                        Next

                    End If
                    cont = cont + 1

                    frase = frase & "<" & reader.Name
                    If (reader.HasAttributes) Then
                        While reader.MoveToNextAttribute
                            frase = frase + reader.Name & ">" & reader.Value
                        End While
                    End If
                    frase = frase & ">"

                Case XmlNodeType.Text
                    If (reader.Name = elemento) Then
                        cont = 2
                    End If
                    If (cont = 2) Then
                        elemento = reader.Name
                    Else
                        For index As Integer = 1 To cont
                            frase = frase & ControlChars.Tab
                        Next

                    End If
                    frase = frase & reader.Value

                Case XmlNodeType.EndElement
                    cont = cont - 1
                    If (reader.Name = elemento) Then
                        cont = 1
                    End If
                    If (cont = 1) Then
                        elemento = reader.Name
                    Else
                        For index As Integer = 1 To cont
                            frase = frase & ControlChars.Tab
                        Next

                    End If
                    frase = frase & "</" + reader.Name
                    frase = frase & ">"
                    frase = frase & vbCrLf



            End Select

        Loop


        Return frase
    End Function
    Public Function Consulta(ruta As String, path As String) As String 'Busca todo los nodos que cuadren con el path y los devuelve en una frase
        Dim frase As String = ""

        Dim docNav As XPathDocument

        Dim nav As XPathNavigator

        Dim nodeIter As XPathNodeIterator

        Dim strExpression As String


        docNav = New XPathDocument(ruta)


        nav = docNav.CreateNavigator


        strExpression = path

        nodeIter = nav.Select(strExpression)

        If nodeIter.Count() > 0 Then


            While (nodeIter.MoveNext())
                frase = frase & nodeIter.Current.Name & ": "
                frase = frase & nodeIter.Current.Value.ToString & vbCrLf
                frase = StrConv(frase, vbProperCase)
            End While
        Else
            frase = frase & "Error xpath"
        End If
        Return frase
    End Function
End Class
