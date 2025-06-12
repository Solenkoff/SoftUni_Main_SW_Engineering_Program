import { Cipher } from "./contracts/cipher";
import { PartialMessageEncoder } from "./contracts/implemented/partialMessageEncoder";
import { Language } from "./contracts/language";


export class LanguageMessageEncoder<TLang extends Language, TCipher extends Cipher<TLang>> extends PartialMessageEncoder {
    private encodedCharsCount = 0;                       
    private decodedCharsCount = 0;

    
    constructor( lang: TLang, cipher: TCipher){          
        super(lang, cipher);
    }     

    public encodeMessage(secretMessage: unknown) {
        if(typeof secretMessage !== 'string' || secretMessage.length === 0){
            return 'No message.';
        }

        const strippedMessage = this.stripForbiddenSymbols(secretMessage);            
        const isCompatible = this.language.isCompatibleToCharset(strippedMessage);    

        if(!isCompatible){
            return 'Message not compatible.';                                         
        }

        const encodedMessage = this.cipher.encipher(strippedMessage);                 
        this.encodedCharsCount += encodedMessage.length;                                   
        return encodedMessage;                                                        
    }

    public decodeMessage(secretMessage: unknown): string {
        if(typeof secretMessage !== 'string' || secretMessage.length === 0){
            return 'No message.';
        }

        const isCompatible = this.language.isCompatibleToCharset(secretMessage);      

        if(!isCompatible){
            return 'Message not compatible.';                                         
        }

        const decodedMessage = this.cipher.decipher(secretMessage);                   
        this.decodedCharsCount += decodedMessage.length;                              
        return decodedMessage;                                                        
    }
    

} 
