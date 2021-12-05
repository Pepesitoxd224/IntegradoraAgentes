from http.server import HTTPServer, BaseHTTPRequestHandler

class MyHandler(BaseHTTPRequestHandler):
    def do_GET(self):

        response = """{
    \"data\": [
        {\"x\":3.5, \"y\":20.0, \"z\":25.85, \"r\":-90},
        {\"x\":-10.6, \"y\":20, \"z\":12.5, \"r\":0}
    ]
}"""
        # send 200 response
        self.send_response(200)
        # send response headers
        self.end_headers()
        # send the body of the response
        self.wfile.write(bytes(response, "utf-8"))

httpd = HTTPServer(('localhost', 8000), MyHandler)
httpd.serve_forever()