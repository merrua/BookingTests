
Setup/Install instructions. 

.Net Framework 4.7.2

1. Place the browser drivers (Firefox (geckodriver), Chrome, Edge in C:\Code\Webdriver
We are using the latest stable at the time of writing. 
Chromedriver 76, https://chromedriver.storage.googleapis.com/index.html?path=76.0.3809.68/
Firefoxdriver v0.24.0, https://github.com/mozilla/geckodriver/releases/tag/v0.24.0
FYI the latest version of edge driver isn't a download but requires an optional install
command, https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/

2. If the browser install location is not the default add it in the BrowserFactory using the 
BrowserExecutableLocation option. Currently its set to use Firefox nightly, but the machine might
have Firefox standard. 

3. Build and install the nuget packages. 
