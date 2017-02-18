from Tkinter import *
import ttk
 
# Test to see if TkInter is working
# tkinter._test()
 
root = Tk()
 
# Frame widgets surround other widgets
frame = Frame(root)
 
# We'll use a TkInter variable for our label text
# so we can change it with set
labelText = StringVar()
 
# Create a label and button object
# You can set attributes on creation or by calling
# methods
 
label = Label(frame, textvariable=labelText)
button = Button(frame, text="Click Me")
 
# Change the label text
labelText.set("I am a label")
 
# Pack positions the widgets in the window
# It is a simple geometry manager
label.pack()
button.pack()
frame.pack()
 
root.mainloop()