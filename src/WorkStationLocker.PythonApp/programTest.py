import time
import datetime
import sys
sys.path.append("./libraries")
import libEmailSender
import keyboard
import credentials

def getCurrentDateTimeStringify():
    return str(datetime.datetime.now()).replace("-", "").replace(":", "").replace(".", "").replace(" ", "")[2:14]

while True:
    if keyboard.is_pressed('enter') or keyboard.is_pressed('space'):
        try:
            subject = f'Lock{getCurrentDateTimeStringify()}'
            content = subject
            receiverEmail = credentials.address
            senderEmail = credentials.address
            senderPassword = credentials.password
            message = libEmailSender.setMessage(subject, content, receiverEmail)
            libEmailSender.sendEmail(message, senderEmail, senderPassword)
        except:
            print("Something went wrong with sending the email")
        finally:
            print("While continues...")