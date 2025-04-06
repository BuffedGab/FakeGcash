Imports System.Data.SqlClient

Partial Class Main
    Inherits System.Web.UI.MasterPage
    Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BankingSystem;Integrated Security=True"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("AccountsID") IsNot Nothing Then
                LoadBalance()
            Else
                Response.Redirect("LoginForm.aspx")
            End If
        End If
    End Sub
    Private Sub LoadBalance()
        Try
            Dim accountID As String = Session("AccountsID").ToString()

            System.Diagnostics.Debug.WriteLine("AccountID from Session: " & accountID)

            Dim query As String = "SELECT AvailableBalance FROM FakeGCashAccounts WHERE AccountsID = @AccountsID"

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@AccountsID", accountID)
                    conn.Open()
                    Dim balance As Object = cmd.ExecuteScalar()

                    System.Diagnostics.Debug.WriteLine("Balance fetched from database: " & balance)

                    If balance IsNot Nothing Then
                        availableBalance.InnerText = "₱" & Convert.ToDecimal(balance).ToString("N2")
                    Else
                        availableBalance.InnerText = "₱0.00"
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading balance: " & ex.Message)
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error loading balance: " & ex.Message & "');", True)
        End Try
    End Sub
    Protected Sub btnAddCash_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Session("AccountsID") IsNot Nothing Then
                Dim accountID As String = Session("AccountsID").ToString()
                Dim amountToAdd As Decimal

                If Decimal.TryParse(txtAddCash.Text, amountToAdd) AndAlso amountToAdd > 0 Then
                    Dim query As String = "UPDATE FakeGCashAccounts SET AvailableBalance = AvailableBalance + @Amount WHERE AccountsID = @AccountsID"

                    Using conn As New SqlConnection(connectionString)
                        Using cmd As New SqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@Amount", amountToAdd)
                            cmd.Parameters.AddWithValue("@AccountsID", accountID)
                            conn.Open()
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    LoadBalance()

                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Cash added successfully!');", True)
                Else
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please enter a valid positive amount.');", True)
                End If
            Else
                Response.Redirect("LoginForm.aspx")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error adding cash: " & ex.Message)
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error adding cash: " & ex.Message & "');", True)
        End Try
    End Sub
    Protected Sub btnLogout_Click(sender As Object, e As EventArgs)
        ' Clear session and redirect to login
        Session.Clear()
        Session.Abandon()
        Response.Redirect("LoginForm.aspx")
    End Sub
End Class
