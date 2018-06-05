# WakeOnLanPortal
Webbased portal using WakeOnLan library

# Library usage
This project is based on the Aquila Technology WakeOnLan library
* Homepage: https://wol.aquilatech.com/
* Source: https://github.com/basildane/WakeOnLAN/

Please create your own 'machines.xml' file bases on the sample (or use the AquilaWOL application to create one).
* Download: https://github.com/basildane/WakeOnLAN/releases/

# Configuration
By default web.config is configured to allow any user to access the portal.

There's also an example on how to use the LDAP (Active directory) authentication for this projecty.

When you are running the project in Visual Studio, you can test the LDAP authentication.

On IIS it's possible to set the authentication on the Virtual Path level (Windows Authentication) and the LDAP authentication will automaticly use those credentials.
