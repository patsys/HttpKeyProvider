from flask import Flask
app = Flask(__name__)


@app.route('/index.html' ,methods = ['GET', 'POST'])
def hello():
    #    return "{\"key\":\"testtest\", \"policy\":{\"Plugins\":false,\"Export\":false,\"ExportNoKey\":false,\"Import\":false,\"Print\":false,\"PrintNoKey\":false,\"NewFile\":true,\"SaveFile\":true,\"AutoType\":true,\"AutoTypeWithoutContext\":false,\"CopyToClipboard\":false,\"CopyWholeEntries\":false,\"DragDrop\":false,\"UnhidePasswords\":false,\"ChangeMasterKey\":false,\"ChangeMasterKeyNoKey\":false,\"EditTriggers\":false}}"
        return '{"key":"printf(\"%s\",\"TestTest\");"}'

    if __name__ == '__main__':
            app.run(host='0.0.0.0', port=6080)
