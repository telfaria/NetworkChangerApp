This document was created with the assistance of ChatGPT, a language model developed by OpenAI.

���{��̐����͉��̂ق��ɂ���܂�

# English

# NetworkChangerApp

NetworkChangerApp is a simple utility application designed to modify network settings, specifically the IP address and related configurations of network adapters.

## How to Use

1. **Select Network Interface**: Choose the desired network interface from the dropdown menu on the left.
2. **Select Profile**: Pick the profile you want to apply from the dropdown menu on the right.
3. **Execute**: Click the "<-" button in the center to execute the process.

Based on the selected profile, the Netsh command will be executed, and the IP address of the specified interface will be changed.

## Sample Profiles

```json
{
    "Profiles": [
        {
            "name": "DHCP",
            "description": "DHCP Setting",
            "ipAddress": "dhcp",
            "netMask": "",
            "gatewayAddress": "",
            "dns": [ "dhcp" ]
        },
        {
            "name": "Profile1",
            "description": "Description1",
            "ipAddress": "192.168.0.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.0.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        },
        {
            "name": "Profile2",
            "description": "Description2",
            "ipAddress": "192.168.1.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.1.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        }
    ]
}
```
These profiles provide examples of both DHCP configuration and static IP configurations for different network scenarios. The profile.json file can be customized with additional profiles as needed.

## Operation
The application executes the Netsh command based on the values defined in the profile. The results of the changes are displayed in the message box at the bottom of the screen.

# ���{��

# NetworkChangerApp

NetworkChangerApp�́A�l�b�g���[�N�A�_�v�^��IP�A�h���X�Ȃǂ̃l�b�g���[�N�ݒ��ύX���邽�߂̃V���v���ȃ��[�e�B���e�B�A�v���P�[�V�����ł��B

## �g�p���@

1. **�l�b�g���[�N�C���^�[�t�F�C�X�̑I��**: �����̃h���b�v�_�E�����j���[����ύX�������l�b�g���[�N�C���^�[�t�F�C�X��I�����܂��B
2. **�v���t�@�C���̑I��**: �E���̃h���b�v�_�E�����j���[����K�p�������v���t�@�C����I�����܂��B
3. **���s**: �^�񒆂� "<-" �{�^�����N���b�N���ď��������s���܂��B

�I�������v���t�@�C���Ɋ�Â��āANetsh�R�}���h�����s����A�w�肳�ꂽ�C���^�[�t�F�C�X��IP�A�h���X���ύX����܂��B

## �v���t�@�C���̗�

```json
{
    "Profiles": [
        {
            "name": "DHCP",
            "description": "DHCP Setting",
            "ipAddress": "dhcp",
            "netMask": "",
            "gatewayAddress": "",
            "dns": [ "dhcp" ]
        },
        {
            "name": "Profile1",
            "description": "Description1",
            "ipAddress": "192.168.0.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.0.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        },
        {
            "name": "Profile2",
            "description": "Description2",
            "ipAddress": "192.168.1.23",
            "netMask": "255.255.255.0",
            "gatewayAddress": "192.168.1.254",
            "dns": [ "8.8.8.8", "8.8.4.4" ]
        }
    ]
}
```
�����̃v���t�@�C���́ADHCP�ݒ�ƐÓIIP�ݒ�̗��񋟂��Ă��܂��Bprofile.json�t�@�C����K�v�ɉ����Ēǉ��̃v���t�@�C���ŃJ�X�^�}�C�Y�ł��܂��B

## ����
�v���t�@�C���Œ�`���ꂽ�l�����ƂɁANetsh�R�}���h�����s���܂��B�ύX�̌��ʂ͉�ʉ����̏o�̓��b�Z�[�W�{�b�N�X�ɕ\������܂��B

