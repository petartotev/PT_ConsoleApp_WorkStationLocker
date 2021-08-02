import time
import datetime
import sys
sys.path.append("./libraries")
import libEmailSender
import credentials

def getCurrentDateTimeStringify():
    return str(datetime.datetime.now()).replace("-", "").replace(":", "").replace(".", "").replace(" ", "")[2:14]

subject = f'Lock{getCurrentDateTimeStringify()}'
content = subject
receiverEmail = credentials.address
senderEmail = credentials.address
senderPassword = credentials.password
message = libEmailSender.setMessage(subject, content, receiverEmail)
libEmailSender.sendEmail(message, senderEmail, senderPassword)
