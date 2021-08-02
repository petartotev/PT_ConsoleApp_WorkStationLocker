import time
import datetime
import sys
sys.path.append("./libraries")
import libEmailSender
import RPi.GPIO as GPIO
import credentials

GPIO.setmode(GPIO.BCM)

TRIG = 23
ECHO = 24

GPIO.setup(TRIG, GPIO.OUT)
GPIO.setup(ECHO, GPIO.IN)

def getCurrentDateTimeStringify():
    return str(datetime.datetime.now()).replace("-", "").replace(":", "").replace(".", "").replace(" ", "")[2:14]

isOnDesk = True

while True:
	try:
        	GPIO.output(TRIG, False)
		time.sleep(2)

		GPIO.output(TRIG, True)
		time.sleep(0.00001)
		GPIO.output(TRIG, False)

		while GPIO.input(ECHO) == 0:
			pulseStart = time.time()

		while GPIO.input(ECHO) == 1:
			pulseEnd = time.time()

		pulseDuration = pulseEnd - pulseStart
		distance = pulseDuration * 17150

		if (distance > 150.00):
			time.sleep(15)
            		if (distance > 150.00 and isOnDesk == True):
				isOnDesk = False
                		subject = f'Lock{getCurrentDateTimeStringify()}'
                		content = subject
                		receiverEmail = credentials.address
                		senderEmail = credentials.address
                		senderPassword = credentials.password
                		message = libEmailSender.setMessage(subject, content, receiverEmail)
                		libEmailSender.sendEmail(message, senderEmail, senderPassword)
               	else:
			isOnDesk = True
 
		print (f'{round(distance, 2)} cm')        

    except KeyboardInterrupt:
        gpio.cleanup()

    finally:
        print()