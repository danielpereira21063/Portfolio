export class ApiException extends Error {
    public readonly message: string = "";

    constructor(message: string) {
        super();

        this.message = message;
        
        this.alertar();
    }


    private alertar() {
        alert(this.message);
    }
}