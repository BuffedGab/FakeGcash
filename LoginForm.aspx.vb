Imports System.Data.SqlClient

Partial Class LoginForm
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim accountID As String = txtAccountNumber.Text

        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BankingSystem;Integrated Security=True"
        Dim query As String = "SELECT AccountsID FROM FakeGCashAccounts WHERE AccountsID = @AccountsID"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AccountsID", accountID)
                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    Session("AccountsID") = accountID
                    Session("LoggedInAccountsID") = accountID
                    Response.Redirect("Home.aspx")
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Invalid Account Number!');", True)
                End If
            End Using
        End Using
    End Sub

End Class

