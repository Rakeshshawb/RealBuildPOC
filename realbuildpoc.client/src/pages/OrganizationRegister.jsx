import { useState } from "react";
import { createOrganization } from "../api/organizationService";

export default function OrganizationRegister() {
    const [org, setOrg] = useState({
        name: "",
        code: "",
        tagLine: "",
        description: "",
        primaryEmail: "",
        primaryPhone: "",
        website: "",
        addressLine1: "",
        addressLine2: "",
        fk_CountryID: "",
        fk_StateID: "",
        fk_CityID: "",
        zipCode: "",
    });

    const [business, setBusiness] = useState({
        bankName: "",
        bankAccountNumber: "",
        bankIFSC: "",
        bankMICR: "",
        bankBranch: "",
    });

    const [statutory, setStatutory] = useState({
        gstNumber: "",
        panNumber: "",
        tanNumber: "",
    });

    const [message, setMessage] = useState("");

    // Handle changes for all sections
    const handleOrgChange = (e) => {
        setOrg({ ...org, [e.target.name]: e.target.value });
    };

    const handleBusinessChange = (e) => {
        setBusiness({ ...business, [e.target.name]: e.target.value });
    };

    const handleStatutoryChange = (e) => {
        setStatutory({ ...statutory, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setMessage("");

        try {
            const payload = {
                organization: org,
                businessDetails: business,
                statutoryDetails: statutory,
            };

            const res = await createOrganization(payload);
            setMessage("Organization created successfully!");
            console.log("Result:", res);
        } catch (err) {
            setMessage(err);
        }
    };

    return (
        <div style={{ width: "500px", margin: "30px auto" }}>
            <h2>Register Organization</h2>

            <form onSubmit={handleSubmit}>

                {/* ORGANIZATION INFO */}
                <h3>Organization Info</h3>
                <input type="text" name="name" placeholder="Organization Name"
                    value={org.name} onChange={handleOrgChange} required />

                <input type="text" name="code" placeholder="Code"
                    value={org.code} onChange={handleOrgChange} required />

                <input type="text" name="tagLine" placeholder="Tag Line"
                    value={org.tagLine} onChange={handleOrgChange} />

                <textarea name="description" placeholder="Description"
                    value={org.description} onChange={handleOrgChange}></textarea>

                <input type="email" name="primaryEmail" placeholder="Primary Email"
                    value={org.primaryEmail} onChange={handleOrgChange} required />

                <input type="text" name="primaryPhone" placeholder="Primary Phone"
                    value={org.primaryPhone} onChange={handleOrgChange} required />

                <input type="text" name="website" placeholder="Website"
                    value={org.website} onChange={handleOrgChange} />

                <input type="text" name="addressLine1" placeholder="Address Line 1"
                    value={org.addressLine1} onChange={handleOrgChange} required />

                <input type="text" name="addressLine2" placeholder="Address Line 2"
                    value={org.addressLine2} onChange={handleOrgChange} />

                <input type="number" name="fk_CountryID" placeholder="Country ID"
                    value={org.fk_CountryID} onChange={handleOrgChange} required />

                <input type="number" name="fk_StateID" placeholder="State ID"
                    value={org.fk_StateID} onChange={handleOrgChange} required />

                <input type="number" name="fk_CityID" placeholder="City ID"
                    value={org.fk_CityID} onChange={handleOrgChange} required />

                <input type="text" name="zipCode" placeholder="Zip Code"
                    value={org.zipCode} onChange={handleOrgChange} required />

                {/* BUSINESS DETAILS */}
                <h3>Business Details</h3>

                <input type="text" name="bankName" placeholder="Bank Name"
                    value={business.bankName} onChange={handleBusinessChange} />

                <input type="text" name="bankAccountNumber" placeholder="Account Number"
                    value={business.bankAccountNumber} onChange={handleBusinessChange} />

                <input type="text" name="bankIFSC" placeholder="Bank IFSC"
                    value={business.bankIFSC} onChange={handleBusinessChange} />

                <input type="text" name="bankMICR" placeholder="Bank MICR"
                    value={business.bankMICR} onChange={handleBusinessChange} />

                <input type="text" name="bankBranch" placeholder="Bank Branch"
                    value={business.bankBranch} onChange={handleBusinessChange} />

                {/* STATUTORY DETAILS */}
                <h3>Statutory Details</h3>

                <input type="text" name="gstNumber" placeholder="GST Number"
                    value={statutory.gstNumber} onChange={handleStatutoryChange} />

                <input type="text" name="panNumber" placeholder="PAN Number"
                    value={statutory.panNumber} onChange={handleStatutoryChange} />

                <input type="text" name="tanNumber" placeholder="TAN Number"
                    value={statutory.tanNumber} onChange={handleStatutoryChange} />

                <button type="submit" style={{ marginTop: "20px" }}>
                    Create Organization
                </button>
            </form>

            {message && <p>{message}</p>}
        </div>
    );
}
