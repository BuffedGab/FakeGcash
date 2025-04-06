Imports System.Data.SqlClient

Public Class BankTransfer
    Inherits System.Web.UI.Page

    Protected Sub SendButton_Click(sender As Object, e As EventArgs)
        Try
            Dim accountNumber As String = txtaccountNumber.Text.Trim()

            ' Avoid blank account number
            If String.IsNullOrEmpty(accountNumber) Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Account Number is required.');", True)
                Exit Sub
            End If

            ' Avoid negative numbers and 0
            Dim amount As Decimal
            If Not Decimal.TryParse(txtamount.Text.Trim(), amount) OrElse amount <= 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please enter a valid amount greater than 0.');", True)
                Exit Sub
            End If

            Dim transactionType As String = ddltransactionType.SelectedValue
            Dim transactionDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim loggedInAccountsID As String = GetLoggedInAccountsID()

            Dim availableBalance As Decimal = GetAvailableBalance(loggedInAccountsID)

            If transactionType = "Deposit" AndAlso availableBalance <= 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('You cannot make a deposit. Your balance is 0. Please add funds to continue.');", True)
                Exit Sub
            End If

            If transactionType = "Deposit" Then
                UpdateAccountBalance(loggedInAccountsID, amount, "Deposit")
            ElseIf transactionType = "Withdraw" Then
                UpdateAccountBalance(loggedInAccountsID, amount, "Withdraw")
            End If

            InsertTransaction(loggedInAccountsID, accountNumber, transactionType, amount, transactionDate)

            Dim successMessage As String = transactionType & " Successful!"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertSuccess", "alert('" & successMessage & "');", True)

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertError", "alert('Error: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
    End Sub

    Private Function GetLoggedInAccountsID() As String
        Return Session("LoggedInAccountsID").ToString()
    End Function
    Private Function GetAvailableBalance(accountID As String) As Decimal
        Dim balance As Decimal = 0
        Dim connStr As String = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BankingSystem;Integrated Security=True"

        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmdText As String = "SELECT AvailableBalance FROM FakeGCashAccounts WHERE AccountsID = @AccountsID"

            Using cmd As New SqlCommand(cmdText, conn)
                cmd.Parameters.AddWithValue("@AccountsID", accountID)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Decimal.TryParse(result.ToString(), balance) Then
                    Return balance
                End If
            End Using
        End Using

        Return balance
    End Function

    Private Sub UpdateAccountBalance(accountNumber As String, amount As Decimal, transactionType As String)
        Dim connStr As String = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BankingSystem;Integrated Security=True"
        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim commandText As String = ""
            If transactionType = "Deposit" Then
                commandText = "UPDATE FakeGCashAccounts SET AvailableBalance = AvailableBalance - @Amount WHERE AccountsID = @AccountsID"
            ElseIf transactionType = "Withdraw" Then
                commandText = "UPDATE FakeGCashAccounts SET AvailableBalance = AvailableBalance + @Amount WHERE AccountsID = @AccountsID"
            End If

            Using cmd As New SqlCommand(commandText, conn)
                cmd.Parameters.AddWithValue("@Amount", amount)
                cmd.Parameters.AddWithValue("@AccountsID", accountNumber)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub InsertTransaction(transferFrom As String, transferTo As String, transactionType As String, amount As Decimal, transactionDate As String)
        Dim connStr As String = "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BankingSystem;Integrated Security=True"
        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim commandText As String = "INSERT INTO FakeGCashTransactions (transactiontype, transferfrom, transferto, date, amount) " &
                                        "VALUES (@TransactionType, @TransferFrom, @TransferTo, @Date, @Amount)"

            Using cmd As New SqlCommand(commandText, conn)
                cmd.Parameters.AddWithValue("@TransactionType", transactionType)
                cmd.Parameters.AddWithValue("@TransferFrom", transferFrom)
                cmd.Parameters.AddWithValue("@TransferTo", transferTo)
                cmd.Parameters.AddWithValue("@Date", transactionDate)
                cmd.Parameters.AddWithValue("@Amount", amount)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
