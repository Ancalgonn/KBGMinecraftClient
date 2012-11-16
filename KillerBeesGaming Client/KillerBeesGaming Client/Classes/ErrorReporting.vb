Imports System.Net.Mail
Imports System.ComponentModel
Public Class ErrorReporting


    '------------------
    'Creator: aeonhack
    'Site: elitevs.net
    'Created: 1/26/2010
    'Changed: 8/13/2012
    'Version: 1.1.0
    '------------------

    'Notes:
    'Raise events in cross-thread operations, no more of that: Cross-thread operation not
    'valid: Control 'NAME' accessed from a thread other than the thread it was created on."

    'It should be noted that Visual Basic hides the delegates for events. You can call them using
    'Name + Event. For example, if we have an event named OperationComplete you would pass the 
    'following into the Raise method: OperationCompleteEvent

    'On a quick side note, I would recommend anyone who is looking at this to also look into
    'AsyncOperation.


    'Declare our event which will be called from a seperate thread.
    Public Event OperationComplete(ByVal data As String)


    'Here we raise our event after converting the text to lowercase.
    Private Sub DoWork(ByVal data As Object)

        'If you raise the event like this and try to access a control in the
        'event handler, it will throw a cross-thread exception.
        '-----------
        'RaiseEvent OperationComplete(DirectCast(data, String).ToLower())
        '-----------

        'However, if you call the Raise method provided below it will safely
        'raise the event on the thread it was created on.
        '-----------
        Raise(OperationCompleteEvent, DirectCast(data, String).ToLower())
        '-----------

    End Sub

    'Assign the data returned from our event to the textbox.
    Private Sub Form1_MyEvent(data As String) Handles Me.OperationComplete
        ' TextBox1.Text = data
    End Sub


    'This is the important part, the rest of the code above is for 
    'demonstration purposes.
    Sub Raise(ByVal [event] As [Delegate], ParamArray data As Object())
        'If the event has no handlers just exit the method call.
        If [event] Is Nothing Then Return

        'Enumerates through the list of handlers.
        For Each D As [Delegate] In [event].GetInvocationList()
            'Casts the handler's parent instance to ISynchronizeInvoke.
            Dim T As ISynchronizeInvoke = DirectCast(D.Target, ISynchronizeInvoke)

            'If an invoke is required (working on a seperate thread) then invoke it
            'on the parent thread, otherwise we can invoke it directly.
            If T.InvokeRequired Then T.Invoke(D, data) Else D.DynamicInvoke(data)
        Next
    End Sub



End Class
