Imports System.Data.SqlClient

Public Class Transaction
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindTransactionHistory()
        End If
    End Sub
    Private Sub BindTransactionHistory()
        Dim accountNumber As String = If(Session("AccountsID"), String.Empty)

        If Not String.IsNullOrEmpty(accountNumber) Then
            Dim connStr As String = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BankingSystem;Integrated Security=True"

            Dim query As String = "SELECT TransactionType, TransferFrom, TransferTo, Amount, Date " & _
                                  "FROM FakeGCashTransactions " & _
                                  "WHERE TransferFrom = @AccountsID " & _
                                  "ORDER BY Date DESC"

            Using conn As New SqlConnection(connStr)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@AccountsID", accountNumber)

                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        TransactionGrid.DataSource = reader
                        TransactionGrid.DataBind()
                    End Using
                End Using
            End Using
        Else
            Response.Redirect("LoginForm.aspx")
        End If
    End Sub

    Protected Sub RefreshButton_Click(sender As Object, e As EventArgs)
        BindTransactionHistory()
    End Sub
End Class
