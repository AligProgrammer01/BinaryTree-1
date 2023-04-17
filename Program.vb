Imports System
' Code writted by AligProgrammer
' Implementation of Binary Tree ADT - V1.0
Module Program
    Class Tree
        Private Structure node
            Dim data As Integer
            Dim leftPointer As Integer
            Dim rightPointer As Integer
        End Structure

        Private Const NullPointer As Integer = -1
        Private treeInstance(10) As node
        Private rootPtr As Integer
        Private FreePtr As Integer

        Public Sub New()
            rootPtr = NullPointer
            FreePtr = 0
            For counter = 0 To 9
                treeInstance(counter).leftPointer = counter + 1
            Next counter
            treeInstance(10).leftPointer = NullPointer
        End Sub


        Public Sub AddItem(item As Integer)
            Dim newNodePtr As Integer
            Dim startPtr As Integer
            Dim previousPtr As Integer
            Dim leftTurn As Boolean = False
            If FreePtr <> NullPointer Then
                newNodePtr = FreePtr
                FreePtr = treeInstance(FreePtr).leftPointer

                treeInstance(newNodePtr).data = item
                treeInstance(newNodePtr).leftPointer = NullPointer
                treeInstance(newNodePtr).rightPointer = NullPointer



                If rootPtr = NullPointer Then
                    rootPtr = newNodePtr
                    Console.WriteLine("Item inserted successfully")
                Else
                    'we now have to go through the tree to see were we want the previous nodes to point to our new item

                    startPtr = rootPtr

                    While startPtr <> NullPointer
                        previousPtr = startPtr
                        If treeInstance(startPtr).data > item Then
                            leftTurn = True
                            startPtr = treeInstance(startPtr).leftPointer
                        Else
                            leftTurn = False
                            startPtr = treeInstance(startPtr).rightPointer
                        End If

                    End While


                    If leftTurn = True Then
                        treeInstance(previousPtr).leftPointer = newNodePtr
                    Else
                        treeInstance(previousPtr).rightPointer = newNodePtr
                    End If

                    Console.WriteLine("Item inserted successfully")
                End If
            Else
                Console.WriteLine("Tree full")

            End If
        End Sub

        Public Sub TraverseTreeRecursively(ByVal Ptr As Integer)
            If Ptr <> NullPointer Then
                TraverseTreeRecursively(treeInstance(Ptr).leftPointer)
                Console.WriteLine(treeInstance(Ptr).data)
                TraverseTreeRecursively(treeInstance(Ptr).rightPointer)
            End If

        End Sub


        Public Function SearchTree(item As Integer) As Integer
            Dim startPtr As Integer = rootPtr
            Dim found As Boolean = False

            While found = False AndAlso startPtr <> NullPointer
                If treeInstance(startPtr).data = item Then
                    Console.WriteLine("Item found")
                    Return startPtr
                End If

                If treeInstance(startPtr).data > item Then
                    startPtr = treeInstance(startPtr).leftPointer
                Else
                    startPtr = treeInstance(startPtr).rightPointer
                End If
            End While

            If found = False Then
                Console.WriteLine("Item not found")
                Return NullPointer
            End If
        End Function

    End Class
    Sub Main()
        ' this method is for test purposes, feel free to edit the main method to use the tree however you want
        Dim mytree As New Tree()

        mytree.AddItem(1)
        mytree.AddItem(100)
        mytree.AddItem(50)
        mytree.AddItem(50)
        mytree.AddItem(87)
        mytree.AddItem(65)
        mytree.AddItem(34)
        mytree.AddItem(23)
        mytree.AddItem(45)
        mytree.AddItem(79)
        mytree.AddItem(10)
        mytree.AddItem(90)
        Console.WriteLine("--------------------")
        mytree.TraverseTreeRecursively(0)
        Console.WriteLine("--------------------")
        Console.WriteLine(mytree.SearchTree(90))
        Console.WriteLine("--------------------")
        Console.WriteLine(mytree.SearchTree(23))

    End Sub
End Module
