require 'rubygems'
require 'json'
require 'net/http'

website = "http://monkeyspace.org"

result = JSON.parse(File.read('sessions.json'))

result.each do | session |
	speakers =  session['speakers']
	speaker = speakers[0]
	headshot = speaker['headshotUrl']

	file_to_download = website + headshot

	Net::HTTP.start('monkeyspace.org') { |http| 
		resp = http.get(headshot)
		open("." + headshot, 'wb')  {|file|
			file.write(resp.body)
		}
		puts "Downloading file " + file_to_download + " to ." + headshot
	}

end 


# open ("http://monkeyspace.org/images/speakers/john_zablocki.jpg") {|f|
# 	File.open("/images/speakers/john_zablocki.jpg", "wb") do | file |
# 		file.puts f.read
# 	end
# }
# http://monkeyspace.org/images/speakers/john_zablocki.jpg